using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;
using ToyCombination = Assets.Scripts.ToyCombination;

[RequireComponent(typeof(GameDataStore))]
public sealed class RandomToyGenerator : MonoBehaviour
{
    public OrderTracker OrderTracker;

    public GameDataStore Store;

    public LevelChanger LevelLoader;

    public Text ScrollText;

    private void Awake()
    {
        Store = GetComponent<GameDataStore>();
        OrderTracker = GameObject.Find("OrderTracker").GetComponent<OrderTracker>();
        LevelLoader = GameObject.Find("LevelChanger").GetComponent<LevelChanger>();
    }

    public void SetupToys()
    {
        var random = new System.Random();

        var toy1 = GenerateNewToy(random);
        var toy2 = GenerateNewToy(random);

        SetupScrollText(new[] { toy1, toy2 }, random);

        OrderTracker.SetRequestedCombinations(new List<ToyCombination> { toy1, toy2 });
    }

    private ToyCombination GenerateNewToy(System.Random random)
    {
        var baseToy = Store.BaseToys[random.Next(0, Store.BaseToys.Length)];

        var topAttachments = Store.ToyAttachments.Where(a =>
            a.ItemPrefab.GetComponentInChildren<AttachmentData>().Slot == AttachmentSlot.Top)
            .ToArray();

        var bottomAttachments = Store.ToyAttachments.Where(a =>
            a.ItemPrefab.GetComponentInChildren<AttachmentData>().Slot == AttachmentSlot.Bottom)
            .ToArray();

        var backAttachments = Store.ToyAttachments.Where(a =>
            a.ItemPrefab.GetComponentInChildren<AttachmentData>().Slot == AttachmentSlot.Back)
            .ToArray();

        var back = backAttachments[random.Next(0, backAttachments.Length)];
        var top = topAttachments[random.Next(0, topAttachments.Length)];
        var bottom = bottomAttachments[random.Next(0, bottomAttachments.Length)];

        var paintJob = Store.PaintJobs[random.Next(0, Store.PaintJobs.Length)];

        return new ToyCombination(baseToy, new[] { back, top, bottom }, paintJob);
    }

    private void SetupScrollText(ToyCombination[] toys, System.Random random)
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.Append("Dear Santa,\n\n");
        stringBuilder.Append(OpeningSentences[random.Next(0, OpeningSentences.Length)] + "\n\n");
        stringBuilder.Append(FollowUps[random.Next(0, FollowUps.Length)]);

        for (var i = 0; i < toys.Length; i++)
        {
            var toy = toys[i];

            if (i > 0)
                stringBuilder.Append("And a");

            stringBuilder.Append($" {toy.ToyBase.FriendlyName}, ");

            stringBuilder.Append(string.Join(", ", toy.ToyAttachments.Select(a => a.PrintablePhrase)));

            stringBuilder.Append("\n\n");
        }

        stringBuilder.Append(Endings[random.Next(0, Endings.Length)] + "\n\n");

        stringBuilder.Append($"From\n{Store.ChildNames[random.Next(0, Store.ChildNames.Length)].childName}");

        ScrollText.text = stringBuilder.ToString();
    }

    private readonly string[] OpeningSentences =
    {
        "This year I was very good",
        "This year was hard, I was very naughty",
        "I tried my best to be good this year",
        "I only started two fires this year",
        "I was on my best behaviour all year",
        "Kids at school say you're not real, but I don't believe them"
    };

    private readonly string[] FollowUps =
    {
        "It would make me very happy if you sent me a",
        "I really want a",
        "This year I'd really like a",
        "Please bring me a"
    };

    private readonly string[] Endings =
    {
        "Or else",
        "Pleeeeease Santa",
        "If you don't, I might cry",
        "If you don't, then I know you're not real",
        "That would make this the best christmas ever!",
        "Maybe then my parents will stop shouting at each other"
    };
}
