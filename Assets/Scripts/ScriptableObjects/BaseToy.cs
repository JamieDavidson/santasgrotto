using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "BaseToy", menuName = "ToyShit/BaseToy")]
    internal sealed class BaseToy : ScriptableObject
    {
        public Sprite mySprite;

        public string friendlyName;
    }
}
