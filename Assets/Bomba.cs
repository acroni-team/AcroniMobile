using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    public Animator bombExplosion;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
           
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        bombExplosion.SetBool("Touched", true);
    }
}
