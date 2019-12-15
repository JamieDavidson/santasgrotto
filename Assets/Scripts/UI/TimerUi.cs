using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public sealed class TimerUi : MonoBehaviour
    {
        private Text m_Text;
        private void Awake()
        {
            m_Text = GetComponentInChildren<Text>();
        }

        public void SetText(string text)
        {
            m_Text.text = $"Time left: {text}";
        }
    }
}
