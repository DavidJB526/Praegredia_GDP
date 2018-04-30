using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenu, creditsMenu;

    public void OnStartClick()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void OnCreditsClick()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }
    public void OnBackClick()
    {
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }
    public void OnQuitClick()
    {
        Application.Quit();
    }
}
