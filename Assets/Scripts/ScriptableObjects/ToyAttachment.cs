using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ToyAttachment", menuName = "ToyShit/ToyAttachment")]
    public sealed class ToyAttachment : ScriptableObject
    {
        public Sprite mySprite;

        public string friendlyName;
    }
}
