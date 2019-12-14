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

        foreach (var toy in m_Store.BaseToys)
        {
            InstantiateToyButton(toy, BaseToyButtonContent);
        }

        foreach (var attachment in m_Store.ToyAttachments)
        {
            InstantiateAttachmentButton(attachment, AttachmentButtonContent);
        }
    }

    public void SwapMenu(int id)
    {
        BaseToyButtonContent.gameObject.SetActive(id == 0);
        AttachmentButtonContent.gameObject.SetActive(id == 1);
    }

    private void InstantiateToyButton(BaseToy toy, Transform content)
    {
        var buttonPrefab = Instantiate(ButtonPrefab);
        buttonPrefab.GetComponent<Button>().onClick.AddListener(() => { m_GameTracker.SelectedBaseToy(toy); });
        buttonPrefab.GetComponentInChildren<Image>().sprite = toy.MySprite;
        buttonPrefab.GetComponentInChildren<Text>().text = toy.FriendlyName;
        buttonPrefab.transform.SetParent(content);
    }

    private void InstantiateAttachmentButton(ToyAttachment attachment, Transform content)
    {
        var buttonPrefab = Instantiate(ButtonPrefab);
        buttonPrefab.GetComponent<Button>().onClick.AddListener(() => { m_GameTracker.AddToyAttachment(attachment); });
        buttonPrefab.GetComponentInChildren<Image>().sprite = attachment.mySprite;
        buttonPrefab.GetComponentInChildren<Text>().text = attachment.friendlyName;
        buttonPrefab.transform.SetParent(content);
    }
}
