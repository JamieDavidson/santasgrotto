using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.ScriptableObjects;
using UnityEngine;

[ExecuteInEditMode]
public sealed class GameDataStore : MonoBehaviour
{
    public BaseToy[] BaseToys;
    public ToyAttachment[] ToyAttachments;
    public PaintJob[] PaintJobs;

    public void PopulateStore(IEnumerable<BaseToy> baseToys, IEnumerable<ToyAttachment> toyAttachments, IEnumerable<PaintJob> paintJobs)
    {
        BaseToys = baseToys.ToArray();
        ToyAttachments = toyAttachments.ToArray();
        PaintJobs = paintJobs.ToArray();
    }
}
