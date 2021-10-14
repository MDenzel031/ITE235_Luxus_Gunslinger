using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinPopScript : MonoBehaviour
{

    private Animator coinAnimation;
    private int currentCoinsToPop;
    private EnemyWithWeapon withWeapon;
    private Enemy Ordinary;

    [HideInInspector]public int coins;

    private Text coinText;




    private void Start()
    {
        coinAnimation = gameObject.GetComponent<Animator>();

        //if(gameObject.GetComponentInChildren<EnemyWithWeapon>() != null)
        //{
        //    withWeapon = gameObject.GetComponent<EnemyWithWeapon>();

        //}
        //else if(gameObject.GetComponentInChildren<Enemy>() != null)
        //{
        //    Ordinary = gameObject.GetComponent<Enemy>();
        //}


        coinText = gameObject.GetComponentInChildren<Text>();
        coinText.text = "+ " + coins.ToString() + " Coins";

    }

    public void destroyText()
    {
        Destroy(gameObject);
    }


}
