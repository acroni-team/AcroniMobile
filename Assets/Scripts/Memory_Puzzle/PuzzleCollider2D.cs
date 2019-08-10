using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCollider2D : MonoBehaviour
{
    PuzzleTilemap puzzleTilemap;

    private void Awake()
    {
        puzzleTilemap = FindObjectOfType<PuzzleTilemap>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Vector3.Dot(collision.GetContact(0).normal,Vector3.down) > 0.5)
        {
            Player.getInstance().TeleportToSpawn();
            puzzleTilemap.Clear();
        }
    }
}