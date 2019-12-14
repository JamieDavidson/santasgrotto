using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public sealed class DisplayToy : MonoBehaviour
{
    private Text childText;

    public void WriteToyDetails(ToyCombination toyCombination)
    {
        // Get references to child object - find text component
        // Write toy details on text child

        if (childText == null)
        {
            childText = GetComponentInChildren<Text>();
        }

        childText.text = toyCombination.ToString();
    }
}
