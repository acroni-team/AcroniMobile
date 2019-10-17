using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class MenuController : MonoBehaviour
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
