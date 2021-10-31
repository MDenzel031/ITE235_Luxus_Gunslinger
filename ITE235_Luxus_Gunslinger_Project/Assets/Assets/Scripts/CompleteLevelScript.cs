using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public class CompleteLevelScript : MonoBehaviour
{
    public GameObject[] panels;
    public Text currentScore;

    //private void Awake()
    //{
    //    foreach(GameObject obj in panels)
    //    {
    //        obj.SetActive(false);
    //    }
    //}

    public void nextLevel()
    {

        int tempScore = int.Parse(currentScore.text);
        PlayerPrefs.SetInt("playerScore", tempScore);

        FindObjectOfType<GameManager>().nextLevel();
    }

    public void Quit()
    {
        PlayerPrefs.DeleteKey("playerScore");
        PlayerPrefs.DeleteKey("Lives");
        SceneManager.LoadScene(0);
    }

    public void levelCompleteMusic()
    {
        FindObjectOfType<AudioManager>().playSound("levelCompleteMusic");
    }
}
