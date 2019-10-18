using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeMenu : MonoBehaviour
{
    public Animator freezeAnimator;
    static FreezeMenu menu;

    public static FreezeMenu GetFreezeMenu()
    {
        return menu;
    }

    void Start()
    {
        menu = this;
    }

    public void FreezeScreen()
    {
        freezeAnimator.SetTrigger("CanAnimate");
        freezeAnimator.SetBool("desacelerate", true);
    }

    public void UnfreezeScreen()
    {
        freezeAnimator.SetTrigger("CanAnimate");
        freezeAnimator.SetBool("desacelerate", false);
    }
}
