using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mace_behavior : MonoBehaviour
{
    #region Public Variables
    public Transform rayCast;
    public LayerMask raycastMask;
    public float rayCastLength;
    public float attackDistance; //Minimum distance for attack
    public float moveSpeed;
    public float timer; //Timer for cooldown between attacks
    public float fireRate = 0.2f;
    public Transform leftLimit;
    public Transform rightLimit;
    public Transform shootArea;
    public GameObject maceBullet;
    #endregion

    #region Private Variables
    private RaycastHit2D hit;
    private Transform target;
    private Animator anim;
    private float distance; //Store the distance b/w enemy and player
    private bool attackMode;
    private bool inRange; //Check if Player is in range
    private bool cooling; //Check if Enemy is cooling after attack
    private float intTimer;
    
    private float nextFire;
    #endregion

    void Awake()
    {
        SelectTarget();
        intTimer = timer; //Store the inital value of timer
        nextFire = Time.time;

    }

    void Update()
    {
        if (!attackMode)
        {
            Move();
        }

        if (!InsideOfLimits() && !inRange)
        {
            SelectTarget();
        }

        if (inRange)
        {
            //hit = Physics2D.Raycast(rayCast.position, -transform.up, rayCastLength, raycastMask);
            EnemyLogic();
            RaycastDebugger();
        }

        //When Player is detected
        if (hit.collider != null)
        {
            EnemyLogic();
        }
        else if (hit.collider == null)
        {
            inRange = false;
        }

        if (inRange == false)
        {
            StopAttack();
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            //target = trig.transform;
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            //target = trig.transform;
            inRange = false;
        }
    }

    private void OnTriggerStay2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            //target = trig.transform;
            inRange = true;
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);

        if (distance > attackDistance)
        {
            StopAttack();
        }
        else if (attackDistance >= distance && cooling == false)
        {
            Attack();
        }

        if (cooling)
        {
            Cooldown();
        }
    }

    void Move()
    {

            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

    }

    void Attack()
    { 

        if(Time.time > nextFire)
        {
            attackMode = true; //To check if Enemy can still attack or not
            Instantiate(maceBullet, shootArea.position, shootArea.rotation);
            FindObjectOfType<AudioManager>().playSound("MaceBullet");
            nextFire = Time.time + fireRate;
        }
            
    }

    void Cooldown()
    {
        attackMode = false;
        timer -= Time.deltaTime;

        if (timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
            attackMode = true;

        }
    }

    void StopAttack()
    {
        cooling = false;
        attackMode = false;
    }

    void RaycastDebugger()
    {
        if (distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, -transform.up * rayCastLength, Color.red);
        }
        else if (attackDistance > distance)
        {
            Debug.DrawRay(rayCast.position, -transform.up * rayCastLength, Color.green);
        }
    }

    public void TriggerCooling()
    {
        cooling = true;
    }

    private bool InsideOfLimits()
    {
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
    }

    private void SelectTarget()
    {
        float distanceToLeft = Vector3.Distance(transform.position, leftLimit.position);
        float distanceToRight = Vector3.Distance(transform.position, rightLimit.position);

        if (distanceToLeft > distanceToRight)
        {
            target = leftLimit;
        }
        else
        {
            target = rightLimit;
        }

        //Ternary Operator
        //target = distanceToLeft > distanceToRight ? leftLimit : rightLimit;

    }

    //void Flip()
    //{
    //    Vector3 rotation = transform.eulerAngles;
    //    if (transform.position.x > target.position.x)
    //    {
    //        //rotation.y = 180;
    //        transform.localScale = new Vector3(1f, 1f, 1f);
    //        shootArea.localScale = new Vector3(1f, 1f, 1f);
    //    }
    //    else
    //    {
    //        //rotation.y = 0;
    //        transform.localScale = new Vector3(-1f, 1f, 1f);
    //        shootArea.localScale = new Vector3(-1f, 1f, 1f);
    //    }

    //    //Ternary Operator
    //    //rotation.y = (currentTarget.position.x < transform.position.x) ? rotation.y = 180f : rotation.y = 0f;

    //    //transform.eulerAngles = rotation;
    //}
}
