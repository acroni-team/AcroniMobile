using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PuzzleCollider2D : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
            Player.getInstance().TeleportToSpawn();
    }
}