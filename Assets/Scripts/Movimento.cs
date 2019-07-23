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

    void Update()
    {
        movHoriz = CrossPlatformInputManager.GetAxis("Horizontal") * velocidade;

        animator.SetFloat("Speed", Mathf.Abs(movHoriz));

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            pular = true;
            animator.SetBool("IsJumping", true);
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {   
        controle.Move(movHoriz * Time.fixedDeltaTime, false, pular);
        pular = false;
    }

}
