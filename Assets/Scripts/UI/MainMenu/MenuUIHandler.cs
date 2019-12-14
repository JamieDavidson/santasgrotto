using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public CanvasGroup MainCanvasGroup;
    public CanvasGroup AboutCanvasGroup;

    public void SwitchCanvasGroup(int id)
    {
        if (id == 0)
        {
            ChangeDisplayCanvasGroup(MainCanvasGroup, true);
            ChangeDisplayCanvasGroup(AboutCanvasGroup, false);
        }
        else if (id == 1)
        {
            ChangeDisplayCanvasGroup(MainCanvasGroup, false);
            ChangeDisplayCanvasGroup(AboutCanvasGroup, true);
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private static void ChangeDisplayCanvasGroup(CanvasGroup group, bool show)
    {
        group.alpha = Convert.ToInt32(show);
        group.blocksRaycasts = show;
        group.interactable = show;
    }
}
