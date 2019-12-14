using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ChildSprite", menuName = "Children/ChildSprite")]
    public sealed class ChildSprite : ScriptableObject
    {
        public Sprite childSprite;
        public string friendlyName;
    }
}
