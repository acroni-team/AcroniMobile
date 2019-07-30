using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartShow : MonoBehaviour
{
    public GameObject player;
    public Cinemachine.CinemachineVirtualCamera cam;
    [Range(0, 1)]
    public float velocity = 0.07f;
    public Movimento player_mvt;

    bool start = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name.Equals("Ada"))
        {
            cam.Follow = player.transform;
            start = true;
            player_mvt.canMove = false;
        }
    }

    void Update()
    {
        if (start)
            player.transform.position = new Vector3(player.transform.position.x + velocity, player.transform.position.y, player.transform.position.z);
    }
}
