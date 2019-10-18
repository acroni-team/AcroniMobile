using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class MenuController : MonoBehaviour
{
    static MenuController instance;

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
