using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;

    void Start()
    {
        gameManager = this;
        DontDestroyOnLoad(this);
    }
    
    public static GameManager GetInstance()
    {
        return gameManager;
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    //static Vector3 postVelocity = Vector3.zero;
    //static float postAngularVelocity = 0f;
    //public Vector3 GetPostVelocity()
    //{
    //    return postVelocity;
    //}
    //public float GetPostAngularVelocity()
    //{
    //    return postAngularVelocity;
    //}
    //public void SetPostVelocity(Vector3 velocity, float angularVelocity)
    //{
    //    postVelocity = velocity;
    //    postAngularVelocity = angularVelocity;
    //}
}
