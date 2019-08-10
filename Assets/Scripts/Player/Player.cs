using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance;

    private void Awake()
    {
        instance = this;
    }

    public static Player getInstance()
    {
        return instance;
    }

    public Vector3[] spawns;
    private int index_spawn = 0;

    public void TeleportToSpawn()
    {
        transform.position = spawns[index_spawn];
    }

    public void NextSpawn()
    {
        if (index_spawn < spawns.Length)
            index_spawn++;
        else
            Debug.LogError("Tá faltando spawns na lista do player!");
    }
}
