using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAngle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        GetComponent<AreaEffector2D>().forceAngle = 90;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider is CircleCollider2D)
            GetComponent<AreaEffector2D>().forceAngle = 60;
        else if (collision.otherCollider is CapsuleCollider2D)
            GetComponent<AreaEffector2D>().forceAngle = 120;
        else
            GetComponent<AreaEffector2D>().forceAngle = 90;
        //Debug.Log(collision.otherCollider.GetType());
    }

}
