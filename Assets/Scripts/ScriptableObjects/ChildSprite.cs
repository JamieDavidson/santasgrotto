using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ChildSprite", menuName = "ChildShit/ChildSprite")]
    public sealed class ChildSprite : ScriptableObject
    {
        public Sprite childSprite;
        public string friendlyName;
    }
}
