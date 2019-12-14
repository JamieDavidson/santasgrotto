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

        public void SelectedBaseToy(BaseToy toy)
        {
            BaseToy = toy;
        }

        public void AddToyAttachment(ToyAttachment attachment)
        {
            ToyAttachments.Add(attachment);
        }

        public void RemoveToyAttachment(ToyAttachment attachment)
        {
            ToyAttachments.Remove(attachment);
        }

        public void SelectedPaintJob(PaintJob paintJob)
        {
            PaintJob = paintJob;
        }

        public ToyCombination FinalizeToyCombination()
        {
            return new ToyCombination(BaseToy, ToyAttachments.ToArray(), PaintJob);
        }
    }
}
