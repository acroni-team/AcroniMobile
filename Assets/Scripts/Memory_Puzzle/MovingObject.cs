using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    bool isMoving = false;
    bool movementDone = false;
    float velocity;

    public bool IsMoving()
    {
        return isMoving;
    }

    public void StartMoving()
    {
        isMoving = true;
    }

    public void StopMoving()
    {
        isMoving = false;
        movementDone = true;
    }

    public bool HasCompletedPath()
    {
        return movementDone;
    }

    public MovingObject Setelocity(float n_velocity)
    {
        velocity = n_velocity;
        return this;
    }

    void FixedUpdate()
    {
        if (isMoving)
            transform.position = new Vector3(transform.position.x + velocity, transform.position.y);
    }
}
