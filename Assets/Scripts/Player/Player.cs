using UnityEngine;

public class Player : MonoBehaviour
{
    static Player instance;
    static Movimento player_movement;

    private void Awake()
    {
        instance = this;
        player_movement = GetComponent<Movimento>();
        //GetComponent<Rigidbody2D>().velocity = GameManager.GetInstance().GetPostVelocity();
        //GetComponent<Rigidbody2D>().angularVelocity = GameManager.GetInstance().GetPostAngularVelocity();
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

    public void ResetSpawn()
    {
        index_spawn = 0;
        TeleportToSpawn();
    }

    public void NextSpawn()
    {
        if (index_spawn < spawns.Length)
        {
            index_spawn++;
            if (index_spawn == spawns.Length - 1)
                CountdownTimer.getInstance().StopTimer();
        }
        else
            Debug.LogError("Tá faltando spawns na lista do player!");
    }
}