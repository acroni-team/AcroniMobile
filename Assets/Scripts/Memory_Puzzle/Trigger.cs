using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.tag.Equals("Player"))
            return;

        Player.getInstance().TeleportToSpawn();
        FindObjectOfType<PuzzleTilemap>().Clear();
    }
}