using Assets.Scripts;
using UnityEngine;

public class OrderTracker : MonoBehaviour
{
    public ToyCombination[] RequestedCombinations;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void OnSceneChange()
    {

    }
}
