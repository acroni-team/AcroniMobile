using UnityEngine;
using Cinemachine;
using UnityEngine.Tilemaps;

public class SwitchFollow : MonoBehaviour
{
    public ShowType type = ShowType.Start;

    public PolygonCollider2D newBounds;
    public GameObject player;
    public Cinemachine.CinemachineVirtualCamera cam;
    [Range(0, 1)]
    public float velocity = 0.07f;
    public Movimento player_mvt;
    public Vector3 newTpLocal;

    static bool movement_done = false;
    bool start = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Ada") && type.Equals(ShowType.Start) && !movement_done)
        {
            player_mvt.canMove = false;
            start = true;
            cam.Follow = player.transform;
            FindObjectOfType<Trigger>().tpLocal = newTpLocal;
        }
        else if (collision.gameObject.CompareTag("showLevel") && type.Equals(ShowType.End) && !movement_done)
        {
            cam.GetComponent<CinemachineConfiner>().m_BoundingShape2D = newBounds;
            start = false;
            movement_done = true;
            player_mvt.canMove = true;
            cam.Follow = player.transform;
        }        
        
    }

    void Update()
    {
        if (start && !movement_done)
            player.transform.position = new Vector3(player.transform.position.x + velocity, player.transform.position.y, player.transform.position.z);
    }

    public enum ShowType
    {
        Start,
        End
    }
}
