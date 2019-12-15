using System;
using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts
{
    public sealed class LevelTimer : MonoBehaviour
    {
        public float MaxTime;
        public float CurrentTime;

        public GameTracker GameTracker;
        public TimerUi TimerUi;

        private bool IsPaused = false;

        private void Update()
        {
            if (IsPaused)
                return;

            CurrentTime += Time.deltaTime;
            var nearestTick = (int)(MaxTime - CurrentTime);
            TimerUi.SetText(new TimeSpan(0, 0, nearestTick).ToString(@"mm\:ss"));
            if (CurrentTime >= MaxTime)
            {
                GameTracker.SubmitDesign();
            }
        }

        public void SetPaused(bool paused)
        {
            IsPaused = paused;
        }
    }
}
