using UnityEngine;

public class Player : MonoBehaviour
{
    static Player instance;
    static Movimento player_movement;

    private void Awake()
    {
        instance = this;
        player_movement = GetComponent<Movimento>();
    }

    public static Player getInstance()
    {
        return instance;
    }

    public Movimento GetPlayerMovement()
    {
        return player_movement;
    }

    public Vector3[] spawns;
    private int index_spawn = 0;

    public void TeleportToSpawn()
    {
            transform.position = spawns[index_spawn];
    }

    public void NextSpawn()
    {
        Debug.Log(index_spawn);
        if (index_spawn < spawns.Length)
            index_spawn++;
        else
            Debug.LogError("Tá faltando spawns na lista do player!");
    }
}