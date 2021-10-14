using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 30;
    public float speed = 20f;
    public Rigidbody2D rb;
    public Vector2 bulletForce;
    public Transform player;

    private void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        EnemyWithWeapon enemy2 = collision.GetComponent<EnemyWithWeapon>();

        if (enemy  != null)
        {

            if (rb.velocity.x < 0)
            {
                enemy.gameObject.GetComponent<Rigidbody2D>().AddForce(-bulletForce, ForceMode2D.Force);
            }
            else
            {
                enemy.gameObject.GetComponent<Rigidbody2D>().AddForce(bulletForce, ForceMode2D.Force);

            }

            enemy.takeDamage(damage);

        }

        if(enemy2 != null)
        {
            enemy2.takeDamage(damage);
        }

        if(collision.tag != "Coins" && collision.gameObject.name != "HotZone")
        {
            Destroy(gameObject);
            Debug.Log(collision.gameObject.name);
        }
    }
}
