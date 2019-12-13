using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Paintjob", menuName = "ToyShit/Paintjob")]
    internal sealed class PaintJob : ScriptableObject
    {
        public string friendlyName;
    }
}
