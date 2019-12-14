using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ChildName", menuName = "ChildShit/ChildName")]
    public sealed class ChildName : ScriptableObject
    {
        public string childName;
    }
}
