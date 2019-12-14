using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "BaseToy", menuName = "ToyShit/BaseToy")]
    public sealed class BaseToy : ScriptableObject
    {
        public Sprite mySprite;

        public string friendlyName;
    }
}
