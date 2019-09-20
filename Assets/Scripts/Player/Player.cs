using UnityEngine;

public class Player : MonoBehaviour
{
    static Player instance;
    static Movimento player_movement;
    static Inventory player_inventory;
    static int player_currency = 500;

    private void Awake()
    {
        instance = this;
        player_movement = GetComponent<Movimento>();
        player_inventory = new Inventory();
    }

    public static Player getInstance()
    {
        return instance;
    }

    public Movimento GetPlayerMovement()
    {
        return player_movement;
    }

    public Inventory GetPlayerInventory()
    {
        return player_inventory;
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

    public int GetPlayerCurrency()
    {
        return player_currency;
    }

    public int RemoveFromPlayerCurrency(int amount)
    {
        if (player_currency >= amount)
            player_currency -= amount;

        return player_currency;
    }
}