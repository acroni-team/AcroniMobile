using UnityEngine;

public class SwitchFollow : MonoBehaviour
{
    public GameObject player;
    public Cinemachine.CinemachineVirtualCamera cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.CompareTag("showLevel"))
        {
            cam.Follow = player.transform;
            Destroy(collision.gameObject);
        }
    }
}
