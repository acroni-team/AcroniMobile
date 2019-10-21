using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampolineJump : MonoBehaviour
{
    private GameObject gameObject;
    public Vector2 velocidade;
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
        
        //collision.gameObject.GetComponent<Rigidbody2D>().AddForce(velocidade, ForceMode2D.Impulse);
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        //if (gameObject.tag.Equals("Player"))
        //{
        //    gameObject.GetComponent<Movimento>().rdb.velocity = new Vector2(30f, gameObject.GetComponent<Movimento>().rdb.velocity.y);
        //}
    }
    void OnCollisionExit2D(Collision2D collision)
    {
    }
}
