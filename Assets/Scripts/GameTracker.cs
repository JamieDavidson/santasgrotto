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

        public void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void SelectedBaseToy(BaseToy toy)
        {
            Debug.Log(toy.FriendlyName);
            BaseToy = toy;
        }

        public void AddToyAttachment(GameObject toyAttachment)
        {
            var data = toyAttachment.GetComponent<AttachmentDataStore>();
            if (data == null)
            {
                Debug.LogError("NO ATTACHMENT DATA FOUND ON OBJECT WE TRIED TO ATTACH");
                return;
            }
            ToyAttachments.Add(data.AttachmentData);
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
    }
}
