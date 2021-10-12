using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedMenu : MonoBehaviour
{

    public GameObject pausePanel;
    public GameObject pauseImage;
    public bool isPause = false;

    public void Resume()
    {
        isPause = false;
        FindObjectOfType<PlayerMovement>().enabled = true;
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        pauseImage.SetActive(true);

    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        isPause = false;
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }


    public void Paused()
    {
        isPause = true;
        FindObjectOfType<PlayerMovement>().enabled = false;
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

}
