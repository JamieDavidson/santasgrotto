using Assets.Scripts;
using UnityEngine;

[RequireComponent(typeof(GameDataStore))]
public sealed class RandomToyGenerator : MonoBehaviour
{
    public DisplayToy ToyUserInterface;

    public ToyCombination CurrentToy;

    public GameDataStore Store;

    private void Awake()
    {
        Store = GetComponent<GameDataStore>();

        CurrentToy = GenerateNewToy();

        ToyUserInterface.WriteToyDetails(CurrentToy);

        print(CurrentToy.ToString());
    }

    private ToyCombination GenerateNewToy()
    {
        var random = new System.Random();
        var baseToy = Store.BaseToys[random.Next(0, Store.BaseToys.Length)];
        var toyAttachment = Store.ToyAttachments[random.Next(0, Store.ToyAttachments.Length)];
        var paintJob = Store.PaintJobs[random.Next(0, Store.PaintJobs.Length)];

        return new ToyCombination(baseToy, new[] { toyAttachment }, paintJob);
    }
}
