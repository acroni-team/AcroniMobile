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

    bool isJumping = false;
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("trampoline"))
            animator.SetBool("IsJumping", true);
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
        }
        else
        {
            animator.SetBool("IsJumping", false);
            useFixUpdate = true;
            //isJumping = false;
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
            if (!isJumping)
                rdb.velocity = Vector3.zero;
        }
            
        pular = false;
    }
}