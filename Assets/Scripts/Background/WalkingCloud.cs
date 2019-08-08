using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingCloud : MonoBehaviour
{
    [Range(0,1)]
    public float velocity;

    private float smoothing = 0.01f;

    void Update()
    {
        transform.position = new Vector3(transform.position.x + velocity * -smoothing, transform.position.y, transform.position.z);
    }
}
