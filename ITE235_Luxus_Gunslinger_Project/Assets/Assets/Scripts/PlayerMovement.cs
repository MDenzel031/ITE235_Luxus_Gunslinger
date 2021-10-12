using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator playerAnimator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    public Joystick joystick;


    bool jump = false;
    bool crouch = false;




    private void Update()
    {
       horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        //if (joystick.Horizontal >= .2f)
        //{
        //    horizontalMove = runSpeed;
        //}
        //else if (joystick.Horizontal <= -.2f)
        //{
        //    horizontalMove = -runSpeed;
        //}
        //else
        //{
        //    horizontalMove = 0f;
        //}


        playerAnimator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            playerAnimator.SetBool("isJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        if (gameObject.transform.position.y < -50f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            playerAnimator.SetBool("isHurt", true);
        }

    }


    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }


    public void onLanding()
    {
        playerAnimator.SetBool("isJumping", false);

    }

    public void Jump()
    {
        jump = true;
        playerAnimator.SetBool("isJumping", true);
    }
}
