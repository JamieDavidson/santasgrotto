using Assets.Scripts;
using Assets.Scripts.ScriptableObjects;
using UnityEngine;

[RequireComponent(typeof(GameDataStore))]
internal sealed class RandomChildGenerator : MonoBehaviour
{
    private ChildCombination currentChild;

    public GameDataStore Store;

    private void Awake()
    {
        Store = GetComponent<GameDataStore>();

        currentChild = GenerateNewChild();

        print(currentChild.ToString());
    }

    private ChildCombination GenerateNewChild()
    {
        var random = new System.Random();
        var childSprite = Store.ChildSprites[random.Next(0, Store.ChildSprites.Length)];
        var childName = Store.ChildNames[random.Next(0, Store.ChildNames.Length)];

        return new ChildCombination(childSprite, childName);
    }
}
