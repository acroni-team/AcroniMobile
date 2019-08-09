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
        Player.getInstance().TeleportToSpawn();
        puzzleTilemap.Clear();
    }
}