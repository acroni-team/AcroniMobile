using UnityEngine;
using Cinemachine;
using UnityEngine.Tilemaps;

public class EnterFollow : MonoBehaviour
{
    public GameObject guider;
    public Cinemachine.CinemachineVirtualCamera cam;
    [Range(0, 1)]
    public float velocity = 0.07f;

    bool start = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player") || guider.GetComponent<MovingObject>().HasCompletedPath())
            return;

        if (!guider.GetComponent<MovingObject>().IsMoving())
        {
            Player.getInstance().GetPlayerMovement().DisableMovement();
            cam.Follow = guider.transform;
            guider.GetComponent<MovingObject>().Setelocity(velocity).StartMoving();
            FindObjectOfType<PuzzleTilemap>().StartShow();
        }  
    }
}