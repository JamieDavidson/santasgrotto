using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.ScriptableObjects;
using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts
{
    public sealed class GameTracker : MonoBehaviour
    {

        public BaseToy BaseToy;
        public List<ToyAttachment> ToyAttachments;
        public PaintJob PaintJob;
        public ToolType SelectedTool;

        public Transform ToyCreationRoot;
        private RandomToyGenerator m_ToyGenerator;
        private GameObject m_BaseToyObject;
        public LevelChanger LevelChanger;
        public LevelTimer GameTimer;

        public void Awake()
        {
            m_ToyGenerator = GetComponent<RandomToyGenerator>();
        }

        public void SelectedBaseToy(BaseToy toy)
        {
            BaseToy = toy;

            DestroyChildren(ToyCreationRoot);

            m_BaseToyObject = Instantiate(BaseToy.ItemPrefab);
            m_BaseToyObject.transform.SetParent(ToyCreationRoot);
            m_BaseToyObject.transform.localPosition = Vector3.zero;
        }

        public void AddToyAttachment(ToyAttachment toyAttachment)
        {
            if (m_BaseToyObject == null)
                return;

            var attachmentObject = Instantiate(toyAttachment.ItemPrefab);
            attachmentObject.transform.SetParent(ToyCreationRoot);

            var attachmentAttachPoint = attachmentObject.GetComponentInChildren<AttachmentData>();
            var slotType = attachmentAttachPoint.Slot;

            var slot = m_BaseToyObject.GetComponentsInChildren<AttachmentData>()
                                      .FirstOrDefault(a => a.Slot == slotType);

            if (slot == null)
            {
                Debug.Log("That don't go there son!");
                return;
            }

            for (var i = 0; i < ToyCreationRoot.childCount; i++)
            {
                var child = ToyCreationRoot.GetChild(i);
                if (child.gameObject == m_BaseToyObject)
                {
                    continue;
                }
                if (child.GetComponentInChildren<AttachmentData>()?.Slot == slotType && attachmentObject != child.gameObject)
                {
                    Destroy(child.gameObject);
                }
            }

            AttachTheThingToTheOtherThing(slot, attachmentAttachPoint);

            ToyAttachments.Add(toyAttachment);
        }

        public void RemoveToyAttachment(ToyAttachment attachment)
        {
            ToyAttachments.Remove(attachment);
        }

        public void SelectedPaintJob(PaintJob paintJob)
        {
            PaintJob = paintJob;
        }

        public void SelectTool(int currentTool)
        {
            SelectedTool = (ToolType)currentTool;

        }

        public ToyCombination FinalizeToyCombination()
        {
            return new ToyCombination(BaseToy, ToyAttachments.ToArray(), PaintJob);
        }

        public void SubmitDesign()
        {
            var timeLeft = GameTimer.MaxTime - GameTimer.CurrentTime;

            GameTimer.SetPaused(true);

            var score = 0;
            var wantedDesign = m_ToyGenerator.CurrentToy;

            if (wantedDesign.ToyBase == BaseToy)
            {
                score++;
            }

            score += wantedDesign.ToyAttachments
                .Count(attachment => ToyAttachments
                .Any(t => t == attachment));

            // didn't get paint finished, don't compare paint job
            //if (wantedDesign.PaintJob == PaintJob)
            //{
            //    score++;
            //}

            var maxScore = wantedDesign.ToyAttachments.Count + 1;

            Debug.Log($"Score is {score} out of {maxScore}");

            LevelChanger.FadeToLevel();
        }

        private static void DestroyChildren(Transform parent)
        {
            for (var i = 0; i < parent.childCount; i++)
            {
                Destroy(parent.GetChild(i).gameObject);
            }
        }

        private static void AttachTheThingToTheOtherThing(AttachmentData toyAttach, AttachmentData attachmentAttach)
        {
            // DO NOT TOUCH - BUG IN UNITY 2019.3.0f3
            // attachmentAttach.transform.position
            // and:
            // var attachmentAttachTransform = attachmentAttach.transform;
            // var attachmentAttachPos = attachmentAttachTransform.position;
            // 
            // give different values!
            // attachmentAttachPos is actually localPosition!
            // FUCK
            var toyAttachPos = toyAttach.transform.position;
            var attachmentParent = attachmentAttach.transform.parent;

            attachmentParent.position = toyAttachPos - attachmentAttach.transform.localPosition;
        }
    }
}
