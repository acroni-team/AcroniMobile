using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    public CharacterController2D controle;
    public float velocidade = 40f;
    float movHoriz = 0f;
    bool pular = false;

    void Update()
    {
        movHoriz = Input.GetAxisRaw("Horizontal") * velocidade;
        if (Input.GetButtonDown("Jump"))
        {
            pular = true;
            
        }
        Debug.Log(Input.GetButtonDown("Jump"));
    }

    void FixedUpdate()
    {   
        controle.Move(movHoriz * Time.fixedDeltaTime, false, pular);
        pular = false;
    }

}
