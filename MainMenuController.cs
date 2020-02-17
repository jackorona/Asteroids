using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject creditsMenu;
    public GameObject howtoMenu;
    public GameObject highscoreMenu;

    public int Points;
    public int playerLives;


    private void Start()
    {
        Points = 0;
        playerLives = 3;
        PlayerPrefs.SetInt("Points", Points);
        PlayerPrefs.SetInt("playerLives", playerLives);
        PlayerPrefs.Save();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1");
    }
    // "SampleScene" must be changed if game scene is renamed.
    public void Options()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
        creditsMenu.SetActive(false);
        howtoMenu.SetActive(false);
        highscoreMenu.SetActive(false);
    }

    public void Howto()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        howtoMenu.SetActive(true);
        highscoreMenu.SetActive(false);
    }

    public void HighScore()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        howtoMenu.SetActive(false);
        highscoreMenu.SetActive(true);
    }
    // SetActive true/false is used to enable or disable a game object. It will enable or disable all of its children too.
    public void Credits()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(true);
        howtoMenu.SetActive(false);
        highscoreMenu.SetActive(false);
    }
    public void Back()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        howtoMenu.SetActive(false);
        highscoreMenu.SetActive(false);
    }
    // Added a back method so we can go back from the options menu to the main menu.
    public void ExitGame()
    {
        Application.Quit();
    }
}
