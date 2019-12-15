using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator Animator;

    public int LevelToLoad;

    public int LastSceneIndex;

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
        LastSceneIndex = LevelToLoad;
        SceneManager.LoadScene(LevelToLoad);
    }
}
