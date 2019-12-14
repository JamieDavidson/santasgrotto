using System.Linq;
using Assets.Scripts;
using Assets.Scripts.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

public class ContentSetup : MonoBehaviour
{
    private GameDataStore m_Store;
    private GameTracker m_GameTracker;

    public Transform BaseToyButtonContent;
    public Transform AttachmentButtonContent;
    public Transform PaintButtonContent;
    public GameObject ButtonPrefab;

    private void Awake()
    {
        m_Store = Camera.main.GetComponent<GameDataStore>();
        m_GameTracker = Camera.main.GetComponent<GameTracker>();

        var toys = m_Store.BaseToys;
        foreach (var toy in toys)
        {
            ButtonThing(toy, BaseToyButtonContent);
        }
    }

    private void ButtonThing(BaseToy toy, Transform content)
    {
        var buttonPrefab = Instantiate(ButtonPrefab);
        buttonPrefab.GetComponent<Button>().onClick.AddListener(() => { m_GameTracker.SelectedBaseToy(toy); });
        buttonPrefab.GetComponent<Image>().sprite = toy.MySprite;
        buttonPrefab.GetComponentInChildren<Text>().text = toy.FriendlyName;
        buttonPrefab.transform.SetParent(content);
    }
}
