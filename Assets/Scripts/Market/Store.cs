using UnityEngine;
using TMPro;

public class Store : MonoBehaviour
{
    public Animator animator;

    public TextMeshProUGUI moneyController;
    static Store store;

    void Start()
    {
        moneyController.text = Player.getInstance().GetPlayerCurrency().ToString() + " A";
    }

    void Awake()
    {
        store = this;
    }

    public static Store GetInstance()
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
        CountdownTimer.getInstance().StopTimer();
        Player.getInstance().GetPlayerMovement().DisableMovement();
        animator.SetBool("isOpen", true);
    }

    public void Close()
    {
        isOpen = false;
        if (!GameManager.GetInstance().IsLevelOver())
            CountdownTimer.getInstance().StartTimer();
        Player.getInstance().GetPlayerMovement().EnableMovement();
        animator.SetBool("isOpen", false);
    }

    bool isOpen = false;
    public bool IsOpen()
    {
        return isOpen;
    }

    public void SetCurrencyDisplay(int money)
    {
        moneyController.text = money.ToString() + " A";
    }

    public void SpeedAnimation()
    {
        animator.SetFloat("multiplier",2);
    }

    public void NormalizeAnimation()
    {
        animator.SetFloat("multiplier", 1);
    }
}
