using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    public void OnStartClick()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void OnCreditsClick()
    {
        SceneManager.LoadScene("Credits");
    }
    public void OnQuitClick()
    {
        Application.Quit();
    }
}
