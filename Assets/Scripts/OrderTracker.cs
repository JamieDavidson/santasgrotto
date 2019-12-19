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
    public int LastSceneIndex;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        SceneManager.sceneLoaded += OnSceneChange;
    }

    public void SetRequestedCombinations(List<ToyCombination> requestedCombinations)
    {
        RequestedCombinations = requestedCombinations.ToList();
        ActualCombinations = new List<ToyCombination>();
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
        LevelLoader = GameObject.Find("LevelChanger").GetComponent<LevelChanger>();
        switch (scene.buildIndex)
        {
            case 2:
                if (LastSceneIndex == 1)
                {
                    // We came from workshop
                    // Load scoring UI
                    Camera.main.GetComponent<ScoreComparer>().DisplayScore(RequestedCombinations.ToArray(),
                                                                           ActualCombinations.ToArray());
                }
                else
                {
                    // We came from main menu or our own scene
                    Camera.main.GetComponent<RandomToyGenerator>().SetupToys();
                }
                break;
        }
    }
}
