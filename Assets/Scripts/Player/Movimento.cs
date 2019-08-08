using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Movimento : MonoBehaviour
{
    public CharacterController2D controle;
    public Animator animator;
    public GameObject ground_check;
    [HideInInspector]
    public bool canMove = true;
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
                animator.SetBool("IsJumping", true);
            }
        }else {
            animator.SetFloat("Speed", 0);
            movHoriz = 0f;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        if (canMove)
            controle.Move(movHoriz * Time.fixedDeltaTime, false, pular);
        else
        {
            rdb.velocity = Vector3.zero;
            rdb.angularVelocity = 0;
        }
            
        pular = false;
    }
}
