using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Store : MonoBehaviour
{
    public Animator animator;

    static Store store;

    void Awake()
    {
        store = this;
    }

    public Store GetInstance()
    {
        return store;
    }

    bool canAnimate = true;
    public void UI_Click()
    {
            animator.SetTrigger("CanAnimate");
        if (!isOpen)
            Open();
        else
            Close();
    }

    public void Open()
    {
        isOpen = true;
        animator.SetBool("isOpen", true);
    }

    public void Close()
    {
        isOpen = false;
        animator.SetBool("isOpen", false);
    }

    bool isOpen = false;
    public bool IsOpen()
    {
        return isOpen;
    }
}
