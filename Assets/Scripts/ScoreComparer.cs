﻿using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public sealed class ScoreComparer : MonoBehaviour
    {
        public Text ScrollText;
        public Button WorkshopButton;
        public Button NewSetButton;

        public void DisplayScore(ToyCombination[] expectedToys,
                                 ToyCombination[] actualToys)
        {
            WorkshopButton.gameObject.SetActive(false);
            NewSetButton.gameObject.SetActive(true);

            var score = 0;
            var stringBuilder = new StringBuilder();

            stringBuilder.Append("YOUR SCORE!\n\n");

            for (var i = 0; i < expectedToys.Length; i++)
            {
                stringBuilder.Append($"Toy {i+1}:\n");

                var expected = expectedToys[i];
                var actual = actualToys[i];

                stringBuilder.Append($"We wanted: {expected.ToyBase.FriendlyName}\n");
                if (expected.ToyBase == actual.ToyBase)
                {
                    stringBuilder.Append($"You chose: {actual.ToyBase.FriendlyName}\n");
                    score += 1000;
                }

                var expectedAttachments = expected.ToyAttachments.ToArray();
                var actualAttachments = actual.ToyAttachments.ToArray();

                for (var j = 0; j < expectedAttachments.Length; j++)
                {
                    var expectedAttachment = expectedAttachments[j];
                    stringBuilder.Append($"We wanted: {expectedAttachment.friendlyName}\n");
                    if (actualAttachments.Any(a => a == expectedAttachment))
                    {
                        stringBuilder.Append("And you got it!\n");
                        score += 1000;
                    }
                    else
                    {
                        stringBuilder.Append("You didn't have it :(\n");
                    }
                }
            }

            stringBuilder.Append($"\nFINAL SCORE: {score}");

            ScrollText.text = stringBuilder.ToString();
        }

        public void LoadWorkshopScene()
        {
            var levelChanger = GameObject.Find("LevelChanger").GetComponent<LevelChanger>();
            levelChanger.LevelToLoad = 1;
            levelChanger.FadeToLevel();
        }

        public void ReloadMallScene()
        {
            var levelChanger = GameObject.Find("LevelChanger").GetComponent<LevelChanger>();
            levelChanger.LevelToLoad = 2;
            levelChanger.FadeToLevel();
        }
    }
}
