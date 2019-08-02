using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpawn : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Ada"))
            FindObjectOfType<Trigger>().tpLocal = new Vector3(51.84f, 1.31f, 0);
    }
}
