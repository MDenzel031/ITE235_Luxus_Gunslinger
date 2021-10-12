using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CompleteLevelScript : MonoBehaviour
{
    public GameObject[] panels;


    //private void Awake()
    //{
    //    foreach(GameObject obj in panels)
    //    {
    //        obj.SetActive(false);
    //    }
    //}

    public void nextLevel()
    {
        FindObjectOfType<GameManager>().restartLevel();
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }

    public void levelCompleteMusic()
    {
        FindObjectOfType<AudioManager>().playSound("levelCompleteMusic");
    }
}
