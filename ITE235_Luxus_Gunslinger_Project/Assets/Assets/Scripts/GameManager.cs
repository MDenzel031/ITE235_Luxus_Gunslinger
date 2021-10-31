using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{

    public Text coinText;
    public Text livesText;
    public GameObject gameOverPanel;
    public GameObject player;
    private Sound deathSoundSource;
    bool isDeathSoundSourcePlaying = false;
    public GameObject playerDeathAnimation;

    private int currentLives;
    private bool isGameOver = false;

    //private void Awake()
    //{

    //    Application.targetFrameRate = 60;
    //}

    private void Start()
    {
        FindObjectOfType<AudioManager>().playSound("Track2");

        deathSoundSource = FindObjectOfType<AudioManager>().getSound("deathSound");
        currentLives = new PreferenceHelper().getLives();
        if(currentLives  != 0)
        {
            livesText.text = currentLives.ToString();
        }
        else
        {
            PlayerPrefs.SetInt("Lives", 3);
            livesText.text = "3";
        }

        try
        {
            int playerScore = PlayerPrefs.GetInt("playerScore");
            if (playerScore != null)
            {
                coinText.text = playerScore.ToString();
            }
        }
        catch(Exception e)
        {
            
        }
    }

    private void Update()
    {
        bool isPause = FindObjectOfType<PausedMenu>().isPause;

        if(isPause == true)
        {
            Sound s = FindObjectOfType<AudioManager>().decreaseSoundVolume("Track2");
            s.source.volume = 0.2f;
        }
        else
        {
            Sound s = FindObjectOfType<AudioManager>().decreaseSoundVolume("Track2");
            s.source.volume = s.volume;
        }


        //AFTER THE SOUND FINISH PLAYING IT WILL RESTART THE LEVEL
        if (isDeathSoundSourcePlaying == true)
        {
            if (!deathSoundSource.source.isPlaying && isGameOver == false)
            {

                FindObjectOfType<GameManager>().restartLevel();
            }
        }
    }

    public void playerDeath()
    {
        //CONTAINS EVERYTHING TO DISABLE THE PLAYERMOVEMNT AND EXECUTE DEATH ANIMATION
        try
        {
            player.GetComponent<BoxCollider2D>().enabled = false;
            player.GetComponent<Rigidbody2D>().gravityScale = 0;
            player.GetComponent<CircleCollider2D>().enabled = false;
            FindObjectOfType<PlayerMovement>().enabled = false;
            FindObjectOfType<CharacterController2D>().enabled = false;
            player.GetComponent<Animator>().SetBool("isHurt", true);
            FindObjectOfType<AudioManager>().stopSound("bgMusic");
            FindObjectOfType<AudioManager>().stopSound("Track2");
            Instantiate(playerDeathAnimation, player.transform.position, player.transform.rotation);
            player.SetActive(false);
            isDeathSoundSourcePlaying = true;
            deathSoundSource.source.Play();
            reduceLives();
        }
        catch(Exception e)
        {

        }
        

    }


    public void gameOver()
    {
        restartLevel();
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void nextLevel()
    {
        int totalIndex = SceneManager.sceneCountInBuildSettings;
        int currentIndex = SceneManager.GetActiveScene().buildIndex;

        if(currentIndex < totalIndex)
        {
            Debug.Log("Current ActiveScene: "+currentIndex.ToString());
            SceneManager.LoadScene(currentIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }


    }



    public void quit()
    {

    }


    public void reduceLives()
    {
        int currentLives = PlayerPrefs.GetInt("Lives") - 1;
        if (currentLives != null && currentLives <= 0)
        {
            new PreferenceHelper().saveData(3);
            gameOverPanel.SetActive(true);
            isGameOver = true;

            PlayerPrefs.DeleteKey("PlayerScore");

        }
        else
        {
            new PreferenceHelper().saveData(currentLives);
        }
    }











    //COINS FUNCTIONS AND METHODS
    public void addAmountToCoins(int amount)
    {
        int currentCoins = int.Parse(coinText.text) + amount;
        FindObjectOfType<AudioManager>().playSound("coinSound");
        coinText.text = currentCoins.ToString();
    }


    public void addSingleCoin()
    {
        int currentCoins = int.Parse(coinText.text) + 1;
        FindObjectOfType<AudioManager>().playSound("coinSound");
        coinText.text = currentCoins.ToString();
    }




}
