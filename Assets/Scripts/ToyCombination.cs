using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.ScriptableObjects;

namespace Assets.Scripts
{
    internal sealed class ToyCombination
    {
        public BaseToy ToyBase { get; }
        public PaintJob PaintJob { get; }
        public IReadOnlyCollection<ToyAttachment> ToyAttachments { get; }
        
        public ToyCombination(BaseToy toyBase,
                              IEnumerable<ToyAttachment> toyAttachments,
                              PaintJob paintJob)
        {
            ToyBase = toyBase;
            PaintJob = paintJob;
            ToyAttachments = toyAttachments.ToArray();
        }

        public override string ToString()
        {
            return $"I want a {ToyBase.friendlyName} painted {PaintJob.friendlyName} with a {string.Join(", ", ToyAttachments.Select(t => t.friendlyName))}";
        }
    }
}
