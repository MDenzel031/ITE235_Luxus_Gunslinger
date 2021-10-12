using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotZoneCheck : MonoBehaviour
{
    private Enemy_behavior EnemyParent;
    private bool inRange;
    public Animator anim;

    private void Awake()
    {
        EnemyParent = GetComponentInParent<Enemy_behavior>();
    }

    private void Update()
    {
        if(inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Attack"))
        {
            EnemyParent.Flip();
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
            EnemyParent.TriggerArea.SetActive(true);
            EnemyParent.inRange = false;
            EnemyParent.SelectTarget();
        }
    }
}
