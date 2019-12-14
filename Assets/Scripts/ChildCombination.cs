using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.ScriptableObjects;

namespace Assets.Scripts
{
    public sealed class ChildCombination
    {
        public ChildSprite ChildSprite { get; }
        public ChildName ChildName { get; }

        public ChildCombination(ChildSprite childSprite, ChildName childName)
        {
            ChildSprite = childSprite;
            ChildName = childName;
        }

        public override string ToString()
        {
            return $"Child with {ChildSprite.friendlyName} sprite and name of {ChildName.childName}";
        }
    }
}
