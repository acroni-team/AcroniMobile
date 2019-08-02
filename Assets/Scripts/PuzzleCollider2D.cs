using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PuzzleCollider2D : MonoBehaviour
{
    public PolygonCollider2D path;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!path.OverlapPoint(collision.transform.position))
            collision.gameObject.transform.position = new Vector3(17.04f, -0.61f, 0);
    }
}