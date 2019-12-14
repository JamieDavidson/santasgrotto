using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ChildName", menuName = "Children/ChildName")]
    public sealed class ChildName : ScriptableObject
    {
        public string childName;
    }
}
