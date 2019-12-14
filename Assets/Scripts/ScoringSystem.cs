using UnityEngine;

namespace Assets.Scripts
{
    public sealed class ScoringSystem : MonoBehaviour
    {
        public void SubmitScore(float timeTaken, ToyCombination expectedCombination, ToyCombination actualCombination)
        {
            // Do some sort of base score, take away time taken, do math shit here
        }
    }
}
