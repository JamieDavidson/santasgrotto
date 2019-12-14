using System.Collections.Generic;
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
        public Transform AttachmentCreationRoot;

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
            Debug.Log("ADDING ATTACHMENT YEET");
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
    }
}
