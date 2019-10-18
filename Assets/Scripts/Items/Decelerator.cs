using UnityEngine;
using System;

public class Decelerator : MonoBehaviour
{
    public float deceleration_rate = 0.5f;
    public int time_slow_down = 10;

    void Start()
    {
        Time.timeScale = 0.5f;
        Freeze();
    }

    void Freeze()
    {
        FreezeMenu.GetFreezeMenu().FreezeScreen();
        AudioManager.GetInstance().DesacelerateSfx();
        CountdownTimer.getInstance().CountTo(time_slow_down);
        Store.GetInstance().SpeedAnimation();
        MenuController.GetInstance().SpeedAnimation();
        Player.getInstance().GetPlayerMovement().SpeedAnimation();
        Destroy(gameObject);
    }
}
