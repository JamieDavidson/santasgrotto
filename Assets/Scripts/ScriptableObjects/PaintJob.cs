using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Paintjob", menuName = "Toys/Paintjob")]
    public sealed class PaintJob : ScriptableObject
    {
        public string friendlyName;
    }
}
