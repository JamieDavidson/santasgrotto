using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.ScriptableObjects;
using UnityEngine;

namespace Assets.Scripts
{
    [ExecuteInEditMode]
    public sealed class GameDataStore : MonoBehaviour
    {
        public BaseToy[] BaseToys;
        public ToyAttachment[] ToyAttachments;
        public PaintJob[] PaintJobs;
        public ChildSprite[] ChildSprites;
        public ChildName[] ChildNames;

        public void PopulateStore(IEnumerable<BaseToy> baseToys,
            IEnumerable<ToyAttachment> toyAttachments,
            IEnumerable<PaintJob> paintJobs,
            IEnumerable<ChildSprite> childSprites,
            IEnumerable<ChildName> childNames)
        {
            BaseToys = baseToys.ToArray();
            ToyAttachments = toyAttachments.ToArray();
            PaintJobs = paintJobs.ToArray();
            ChildSprites = childSprites.ToArray();
            ChildNames = childNames.ToArray();
        }
    }
}
