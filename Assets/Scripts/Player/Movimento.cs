using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Movimento : MonoBehaviour
{
    public CharacterController2D controle;
    public Animator animator;
    public GameObject ground_check;
    public float velocidade = 40f;

    float movHoriz = 0f;
    bool pular = false;
    Rigidbody2D rdb;

    void Start()
    {
        rdb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (canMove)
        {
            movHoriz = CrossPlatformInputManager.GetAxis("Horizontal") * velocidade;

            animator.SetFloat("Speed", Mathf.Abs(movHoriz));

            if (CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                pular = true;
                isJumping = true;
                animator.SetBool("IsJumping", true);
            }
        }else {
            animator.SetFloat("Speed", 0);
            movHoriz = 0f;
        }
    }

    bool canMove = true;
    public void EnableMovement()
    {
        canMove = true;
    }
    public void DisableMovement()
    {
        canMove = false;
    }
    public void EnableAddForce()
    {
        isAddingForce = true;
    }
    public void DisableAddForce()
    {
        isAddingForce = false;
    }
    public void StartJumpAnimation()
    {
        animator.SetBool("IsJumping", true);
    }
    public bool getIsAddingForce()
    {
        return isAddingForce;
    }
    bool isJumping = false;
    bool isAddingForce = false;
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("trampoline"))
        {
            animator.SetBool("IsJumping", true);
            Player.getInstance().GetPlayerMovement().EnableMovement();

        }
    }

    bool useFixUpdate = true;
    public void OnCollisionEnter2D(Collision2D collider2d)
    {
        if (collider2d.gameObject.tag.Equals("trampoline"))
        {
            if (isJumping)
            {
                useFixUpdate = false;
                animator.SetBool("IsJumping", false);
            }
            else
            {
                animator.SetBool("IsJumping", true);
                useFixUpdate = false;
                //Jumping = true;
            }
            Player.getInstance().GetPlayerMovement().DisableMovement();
            Player.getInstance().GetPlayerMovement().EnableAddForce();
        }
        else
        {
            animator.SetBool("IsJumping", false);
            isJumping = false;
            DisableAddForce();
        }
    }
    void FixedUpdate()
    {
        if (!useFixUpdate)
            return;

        if (canMove)
            controle.Move(movHoriz * Time.fixedDeltaTime, false, pular);
        else
        {
            if (!isAddingForce)
                if (!isJumping)
                    rdb.velocity = Vector3.zero;
        }
            
        pular = false;
    }
}