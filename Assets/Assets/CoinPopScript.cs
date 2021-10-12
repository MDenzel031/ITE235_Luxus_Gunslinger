using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPopScript : MonoBehaviour
{

    private Animator coinAnimation;

    private void Start()
    {
        coinAnimation = gameObject.GetComponent<Animator>();

    }

    public void destroyText()
    {
        Destroy(gameObject);
    }


}
