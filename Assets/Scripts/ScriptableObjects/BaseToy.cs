using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "BaseToy", menuName = "ToyShit/BaseToy")]
    public sealed class BaseToy : ScriptableObject
    {
        public Sprite MySprite;

        public string FriendlyName;
    }
}
