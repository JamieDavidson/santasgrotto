using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ToyAttachment", menuName = "Toys/ToyAttachment")]
    public sealed class ToyAttachment : ScriptableObject
    {
        public Sprite mySprite;

        public string friendlyName;

        public string PrintablePhrase;

        public GameObject ItemPrefab;
    }
}
