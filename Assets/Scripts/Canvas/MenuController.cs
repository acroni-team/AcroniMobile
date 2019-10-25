using System;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Experimental.UIElements;
using UnityStandardAssets.CrossPlatformInput;

public class MenuController : MonoBehaviour
{
    static MenuController instance;

    public UnityEngine.UI.Button[] moveButtons;
    public UnityEngine.UI.Button storeButton;

    public static MenuController GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        instance = this;
    }

    public Animator animator;

    bool isOpen = false;
    public void OnClick()
    {
        animator.SetTrigger("CanAnimate");

        for (int i = 0; i < 3; i++)
        {
            moveButtons[i].enabled = isOpen;
            try
            {
                moveButtons[i].GetComponent<AxisTouchButton>().enabled = isOpen;
            }catch(Exception)
            {
                moveButtons[i].GetComponent<ButtonHandler>().Name = (isOpen)?"Jump":"Jum";
            }
        }
        storeButton.enabled = isOpen;
        InventoryController.GetInventoryController().SetInteractible(isOpen);

        if (isOpen)
            CountdownTimer.getInstance().StartTimer();
        else
            CountdownTimer.getInstance().StopTimer();

        isOpen = (isOpen) ? false : true;

        animator.SetBool("isOpen", isOpen);
    }

    public void SpeedAnimation()
    {
        animator.SetFloat("multiplier", 2);
    }

    public void NormalizeAnimation()
    {
        animator.SetFloat("multiplier", 1);
    }
}
