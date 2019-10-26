using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public Animator animator;

    bool isOpen = false;
    public void OnClick()
    {
        animator.SetTrigger("CanAnimate");
        isOpen = (isOpen) ? false : true;
        animator.SetBool("isOpen", isOpen);
    }

}
