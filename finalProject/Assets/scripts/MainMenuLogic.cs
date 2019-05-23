using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLogic : MonoBehaviour
{

    public GameObject MainMenuPanel;
    public GameObject CreditsPanel;


    // Start is called before the first frame update
    void Start()
    {
        MainMenuPanel.SetActive(true);
        CreditsPanel.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene("Exercise 1");
    }

    public void Credits()
    {
        MainMenuPanel.SetActive(false);
        CreditsPanel.SetActive(true);
    }

    public void MainMenu()
    {
        MainMenuPanel.SetActive(true);
        CreditsPanel.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
