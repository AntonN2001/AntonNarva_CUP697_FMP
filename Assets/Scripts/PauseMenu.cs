using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    [SerializeField] private GameObject playerUI;
    [SerializeField] private GameObject BossUI;
    private bool gameIsPaused;
    BossTrigger bossTrigger;

    void Start()
    {
        Time.timeScale = 1;
        playerUI.SetActive(true);
        gameIsPaused = false;
        PausePanel.SetActive(false);
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gameIsPaused == false)
        {
            gameIsPaused = true;
            Pause();
        }
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        playerUI.SetActive(false);
        BossUI.SetActive(false);

        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach(AudioSource a in audios)
        {
            a.Pause();
        }
    }

    public void Continue()
    {
        gameIsPaused = false;
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerUI.SetActive(true);
        BossUI.SetActive(true);

        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach (AudioSource a in audios)
        {
            a.Play();
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
