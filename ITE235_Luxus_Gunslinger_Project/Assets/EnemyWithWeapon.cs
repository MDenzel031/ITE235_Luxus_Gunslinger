using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWithWeapon : MonoBehaviour
{

    public int maxHealth = 100;
    public int coinPoints = 5;
    int currentHealth;
    public int damage = 20;

    public HealthBar healthbar;
    public GameObject popupCoin;
    public GameObject deathAnimation;
    public bool hasDeathAnimation;
    public GameObject hitBox;



    void Start()
    {
        currentHealth = maxHealth;
        healthbar.setMaxHealth(maxHealth);

    }    

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.setHealth(currentHealth);
        FindObjectOfType<AudioManager>().playSound("enemyHit");
        if (currentHealth <= 0)
        {
            if (hasDeathAnimation)
            {
                deathAnimation.transform.localScale = gameObject.transform.localScale;
                Instantiate(deathAnimation, gameObject.transform.position, gameObject.transform.rotation);
                destroyEnemy();
            }
            else
            {
                destroyEnemy();
            }
        }
    }


    void destroyEnemy()
    {


        Instantiate(popupCoin, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
        FindObjectOfType<GameManager>().addAmountToCoins(coinPoints);



    }

    public void enableWeaponHitbox()
    {
        hitBox.SetActive(true);
    }

    public void disableWeaponHitbox()
    {
        hitBox.SetActive(false);

    }


}
