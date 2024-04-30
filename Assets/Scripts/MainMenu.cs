using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject selectionMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject titleText;

    void Start()
    {
        titleText.SetActive(true);
        mainMenu.SetActive(true);
        selectionMenu.SetActive(false);
        optionsMenu.SetActive(false);
    }

    public void PlayGame()
    {
        titleText.SetActive(false);
        mainMenu.SetActive(false);
        selectionMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void OptionsMenu()
    {
        titleText.SetActive(false);
        mainMenu.SetActive(false);
        selectionMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Game");
    }

    public void LoadLevelTutorial()
    {
        SceneManager.LoadScene("TutorialLevel");
    }

    public void LoadLevelA()
    {
        SceneManager.LoadScene("LevelA");
    }

    public void LoadLevelB()
    {
        SceneManager.LoadScene("LevelB");
    }

    public void LoadLevelBoss()
    {
        SceneManager.LoadScene("BossLevel");
    }

    public void SelectAbility1()
    {

    }

    public void SelectAbility2()
    {

    }

    public void SelectAbility3()
    {

    }

    public void ReturnToMainMenu()
    {
        titleText.SetActive(true);
        mainMenu.SetActive(true);
        selectionMenu.SetActive(false);
        optionsMenu.SetActive(false);
    }
}
