using Assets.Scripts.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.BottomMenu
{
    public sealed class PaintJobMenuButton : MonoBehaviour
    {
        private PaintJob m_PaintJob;
        private Button m_Button;
        private GameTracker m_Tracker;

        public void Initialize(PaintJob paintJob)
        {
            m_PaintJob = paintJob;
            m_Button = GetComponent<Button>();
            m_Tracker = Camera.main.GetComponent<GameTracker>();

            m_Button.onClick.AddListener(() => m_Tracker.SelectedPaintJob(m_PaintJob));
        }
    }
}
