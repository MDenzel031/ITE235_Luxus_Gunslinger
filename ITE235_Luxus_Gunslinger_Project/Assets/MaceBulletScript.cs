using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceBulletScript : MonoBehaviour
{
    public int damage = 10;
    public float speed = 15f;
    public Rigidbody2D rb;
    public Vector2 bulletForce;
    public Transform player;

    private void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth player = collision.GetComponent<PlayerHealth>();

        Debug.Log(collision.gameObject.name);

        if (player != null)
        {

            if (rb.velocity.x < 0)
            {
                player.gameObject.GetComponent<Rigidbody2D>().AddForce(-bulletForce, ForceMode2D.Force);
            }
            else
            {
                player.gameObject.GetComponent<Rigidbody2D>().AddForce(bulletForce, ForceMode2D.Force);

            }

            player.takeDamage(damage);

        }

        if (collision.tag != "Coins")
        {
            Destroy(gameObject);
        }
    }
}
