using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{


    public Text highScore;

    private void Start()
    {
        try
        {
            int currentHighScore = PlayerPrefs.GetInt("HighScore");
            if (currentHighScore != null)
            {
                highScore.text = "HIGHEST SCORE: " + currentHighScore.ToString();
            }
            else
            {
                highScore.text = "HIGHEST SCORE: 0";
            }
        }catch(Exception e)
        {

        }
    }


    public void StartGame()
    {
        PlayerPrefs.DeleteKey("Lives");
        PlayerPrefs.DeleteKey("playerScore");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void Exit()
    {
        Application.Quit();
    }

}
