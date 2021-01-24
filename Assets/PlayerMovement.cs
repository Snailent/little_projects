using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    float horizontalMove = 0f;
    public float runSpeed = 40f;
    public float acttackSpeed;
    bool jump = false;
    bool crouch = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            acttackSpeed = 1f;
            animator.SetFloat("isAttacking", acttackSpeed);
            acttackSpeed = 0f;
            animator.SetFloat("isAttckging", acttackSpeed);
        }
        if (Input.GetButtonDown("Up"))
        {
            crouch = true;
        } else if (Input.GetButtonDown("Down"))
        {
            crouch = false;
        }
    }

    public void onLanding()
    {
        animator.SetBool("isJumping", false);
    }

    public void onAttacking()
    {
        animator.SetBool("isAttacking", false);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
