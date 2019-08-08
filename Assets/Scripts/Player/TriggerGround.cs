using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGround : MonoBehaviour
{
    CharacterController2D c;

    private void Awake()
    {
        c = GetComponent<CharacterController2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        c.OnLandEvent.Invoke();
    }
}