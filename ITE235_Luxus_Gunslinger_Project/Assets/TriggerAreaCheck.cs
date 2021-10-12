using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaCheck : MonoBehaviour
{
    private Goblin_behavior goblin_behavior;

    private void Awake()
    {
        goblin_behavior = GetComponentInParent<Goblin_behavior>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            goblin_behavior.target = collision.transform;
            goblin_behavior.inRange = true;
            goblin_behavior.hotZone.SetActive(true);
        }
    }
}
