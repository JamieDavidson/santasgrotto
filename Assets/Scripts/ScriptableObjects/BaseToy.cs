using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "BaseToy", menuName = "Toys/BaseToy")]
    public sealed class BaseToy : ScriptableObject
    {
        public Sprite MySprite;

        public string FriendlyName;

        public GameObject ItemPrefab;
    }
}
