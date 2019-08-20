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

    float enter = 1;
    void FixedUpdate()
    {
        enter = enter > 0.001? rdb.velocity.x : 0;
        if (canMove)
            controle.Move(movHoriz * Time.fixedDeltaTime, false, pular);
        else
        {
            enter = enter - 0.025f;
            rdb.velocity = new Vector3(enter, rdb.velocity.y, 0);
            rdb.angularVelocity = 0;
        }
            
        pular = false;
    }
}
