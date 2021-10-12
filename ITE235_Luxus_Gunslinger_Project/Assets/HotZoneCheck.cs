using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotZoneCheck : MonoBehaviour
{
    private Goblin_behavior goblin_behavior;
    private bool inRange;
    private Animator anim;

    private void Awake()
    {
        goblin_behavior = GetComponentInParent<Goblin_behavior>();
        anim = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        if(inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Attack"))
        {
            goblin_behavior.Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
            gameObject.SetActive(false);
            goblin_behavior.hotZone.SetActive(true);
            goblin_behavior.inRange = false;
            goblin_behavior.SelectTarget();
        }
    }
}
