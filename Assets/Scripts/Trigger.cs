using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{

    public Vector3 tpLocal;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position = new Vector3(tpLocal.x, tpLocal.y, tpLocal.z);
        
    }
}
