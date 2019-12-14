using Assets.Scripts.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.BottomMenu
{
    public sealed class ToyAttachmentMenuButton : MonoBehaviour
    {
        private ToyAttachment m_Attachment;
        private Button m_Button;
        private GameTracker m_Tracker;

        public void Initialize(ToyAttachment attachment)
        {
            m_Attachment = attachment;
            m_Button = GetComponent<Button>();
            m_Tracker = Camera.main.GetComponent<GameTracker>();

            m_Button.onClick.AddListener(() => m_Tracker.AddToyAttachment(m_Attachment));
        }
    }
}
