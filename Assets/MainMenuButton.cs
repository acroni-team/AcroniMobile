using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButton : MonoBehaviour
{
   
    public void OnClick()
    {
        AudioManager.GetInstance().Stop("bgm-aero_plano");
        GameManager.GetInstance().LoadScene("Menu_principal");
    }
}