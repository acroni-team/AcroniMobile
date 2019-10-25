using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;

    bool isLevelOver = false;

    void Start()
    {
        if (gameManager == null)
            gameManager = this;

        DontDestroyOnLoad(this);
    }
    
    public static GameManager GetInstance()
    {
        return gameManager;
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void GameOver(string scene_name)
    {
        LoadScene(scene_name);
    }

    public bool IsLevelOver()
    {
        return isLevelOver;
    }

    public void EndLevel()
    {
        isLevelOver = true;
    }

    public void StartGame()
    {
        AudioManager.GetInstance().Stop("bgm-ada_theme");
        LoadScene("nova_aerea");
    }
}