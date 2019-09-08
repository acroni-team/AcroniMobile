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

        if (isCompleted)
        {
            //GameManager.GetInstance().SetPostVelocity(Player.getInstance().GetComponent<Rigidbody2D>().velocity,Player.getInstance().GetComponent<Rigidbody2D>().angularVelocity);
            GameManager.GetInstance().LoadScene("nova_aerea");
            return;
        }

        currentSeconds -= 1 * Time.deltaTime;
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
}
