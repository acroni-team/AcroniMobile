using Cinemachine;
using UnityEngine;

public class ExitFollow : MonoBehaviour
{
    public PolygonCollider2D newBounds;
    public GameObject player;
    public Cinemachine.CinemachineVirtualCamera cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("showLevel") || collision.GetComponent<MovingObject>().HasCompletedPath())
            return;

        if (collision.GetComponent<MovingObject>().IsMoving())
        {
            cam.GetComponent<CinemachineConfiner>().m_BoundingShape2D = newBounds;
            collision.GetComponent<MovingObject>().StopMoving();
            Player.getInstance().GetPlayerMovement().EnableMovement();
            cam.Follow = player.transform;
        }
    }
}
