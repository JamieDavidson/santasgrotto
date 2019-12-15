using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator Animator;

    public int LevelToLoad;

    public void Awake()
    {
        if (Animator == null)
        {
            Animator = GetComponent<Animator>();
        }
        Animator = GetComponent<Animator>();
    }

    public void FadeToLevel()
    {
        Animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        GameObject.Find("OrderTracker").GetComponent<OrderTracker>().LastSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(LevelToLoad);
    }
}
