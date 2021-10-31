using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class completion : MonoBehaviour
{

    public Text finalScore;
    public Text displayScore;


    private void Start()
    {
        displayScore.text = finalScore.text.ToString(); 
    }


    public void Quit()
    {



        try
        {

            Debug.Log("yOU aCCECSS THE HIGHSCORE");
            PlayerPrefs.DeleteKey("playerScore");
            PlayerPrefs.DeleteKey("Lives");

            int currentHighScore = PlayerPrefs.GetInt("HighScore");
            int newScore = int.Parse(finalScore.text.ToString());

            if (newScore >= currentHighScore)
            {
                PlayerPrefs.SetInt("HighScore", int.Parse(finalScore.text.ToString()));

            }

            Debug.Log("THE HIGHSCORE IS: " + currentHighScore);

        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        
    }

    public void victoryMusic()
    {
        Debug.Log("Victory Music is Playing");
        FindObjectOfType<AudioManager>().playSound("VictoryMusic");
    }



}
