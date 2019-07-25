using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    public GameObject cam;
    public Rigidbody2D player;
    public float parallaxEffect;
    private float smoothing = 0.05f;

    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float dist = (cam.transform.position.x * (1 - parallaxEffect) * smoothing * -Mathf.Sign(player.velocity.x));
        transform.position = new Vector3(transform.position.x - dist, transform.position.y, transform.position.z);
        

        //if (temp > startpos + length) startpos += length;
        //else if (temp < startpos + length) startpos -= length;
    }
}