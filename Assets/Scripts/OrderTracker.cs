using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OrderTracker : MonoBehaviour
{
    public List<ToyCombination> RequestedCombinations = new List<ToyCombination>();
    public List<ToyCombination> ActualCombinations = new List<ToyCombination>();

    public LevelChanger LevelLoader;

    public RandomToyGenerator RandomToys;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        SceneManager.sceneLoaded += OnSceneChange;

        LevelLoader = GameObject.Find("LevelChanger").GetComponent<LevelChanger>();
    }

    public void SetRequestedCombinations(List<ToyCombination> requestedCombinations)
    {
        RequestedCombinations = requestedCombinations.ToList();
    }

    public void AddOrder(ToyCombination combination)
    {
        ActualCombinations.Add(combination);
    }

    public void ConfirmPlayerReadTheThing()
    {
        LevelLoader.FadeToLevel();
    }

    private void OnSceneChange(Scene scene, LoadSceneMode sceneMode)
    {
        switch (scene.buildIndex)
        {
            case 2:
                if (LevelLoader.LastSceneIndex == 1)
                {
                    // We came from workshop
                    // Load scoring UI

                }
                else
                {
                    // We came from main menu or our own scene
                    RandomToys.SetupToys();
                }
                break;
        }
    }
}
