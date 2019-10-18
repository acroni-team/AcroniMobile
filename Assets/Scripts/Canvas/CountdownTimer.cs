using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float minutes;
    public float seconds;

    TextMeshProUGUI timer;
    float currentSeconds = 0f;
    float currentMinutes = 0f;
    bool isCompleted = false;
    static CountdownTimer countdownTimer;

    void Start()
    {
        currentMinutes = minutes;
        currentSeconds = seconds;
        timer = GetComponent<TextMeshProUGUI>();
        countdownTimer = this;
    }

    public static CountdownTimer getInstance()
    {
        return countdownTimer;
    }

    bool isRunning = true;
    public void StopTimer()
    {
        isRunning = false;
        FindObjectOfType<PuzzleTilemap>().Clear();
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    void Update()
    {
        if (!isRunning)
            return;

        if(countTo > 0)
        {
            countTo -= 1 * Time.unscaledDeltaTime;
            timer.color = new Color32(161, 0, 255, 255);
            if(countTo > 0)
                timer.text = Mathf.FloorToInt(countTo).ToString();

            if(countTo > 0 && countTo < 0.5)
            {
                AudioManager.GetInstance().AcelerateSfx();
                FreezeMenu.GetFreezeMenu().UnfreezeScreen();
                Store.GetInstance().NormalizeAnimation();
                MenuController.GetInstance().NormalizeAnimation();
                Player.getInstance().GetPlayerMovement().NormalizeAnimation();
                Time.timeScale = 1;
            }
            return;
        }

        if(timer.color.Equals(new Color32(161,0,255,255)))
            timer.color = new Color32(161,161,161,255);

        if (isCompleted)
        {
            GameManager.GetInstance().GameOver("nova_aerea");
            return;
        }

        currentSeconds -= 1 * Time.unscaledDeltaTime;
        int sec = Mathf.FloorToInt(currentSeconds);

        if (currentSeconds <= 0 && currentMinutes == 0)
        {
            isCompleted = true;
            return;
        }

        timer.text = (currentMinutes != 0?currentMinutes+":":"") + (sec > 9?sec +"":("0"+sec));

        if (currentSeconds <= 0 && currentMinutes != 0)
        {
            currentSeconds = 60;
            currentMinutes--;
        }
    }

    float countTo = 0;
    public void CountTo(int seconds)
    {
        countTo = ++seconds;
    }
}