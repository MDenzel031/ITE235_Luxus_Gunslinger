using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Hitbox : MonoBehaviour
{

    public int axeDamage = 5;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerHealth player = collision.GetComponent<PlayerHealth>();

            if(player != null)
            {
                player.takeDamage(axeDamage);
            }
        }
    }
}
