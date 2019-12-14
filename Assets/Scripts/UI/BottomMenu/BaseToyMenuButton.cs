using Assets.Scripts;
using Assets.Scripts.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

public class BaseToyMenuButton : MonoBehaviour
{
    private BaseToy m_Toy;
    private Button m_Button;
    private GameTracker m_Tracker;

    public void Initialize(BaseToy toy)
    {
        m_Toy = toy;
        m_Button = GetComponent<Button>();
        m_Tracker = Camera.main.GetComponent<GameTracker>();

        m_Button.onClick.AddListener(() => m_Tracker.SelectedBaseToy(m_Toy));
    }
}
