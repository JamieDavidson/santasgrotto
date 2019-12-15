using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.ScriptableObjects;
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

        private GameObject m_BaseToyObject;

        public void Awake()
        {
            DontDestroyOnLoad(this);
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

            var attachmentAttachPoint = attachmentObject.GetComponent<AttachmentData>();
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
                if (child.GetComponent<AttachmentData>()?.Slot == slotType && attachmentObject != child.gameObject)
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

        private static void DestroyChildren(Transform parent)
        {
            for (var i = 0; i < parent.childCount; i++)
            {
                Destroy(parent.GetChild(i).gameObject);
            }
        }

        private static void AttachTheThingToTheOtherThing(AttachmentData toyAttach, AttachmentData attachmentAttach)
        {
            var toyAttachPos = toyAttach.transform.localPosition;
            var attachmentAttachTransform = attachmentAttach.transform;
            var attachmentAttachPos = attachmentAttachTransform.localPosition;

            var diff = toyAttachPos - attachmentAttachPos;

            var newPos = attachmentAttachPos + diff;
            attachmentAttachTransform.localPosition = newPos;
        }
    }
}
