using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    public GameObject cam;
    
    public float parallaxEffect;

    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        transform.position = new Vector3(cam.transform.position.x, transform.position.y, transform.position.z);   

        //if (temp > startpos + length) startpos += length;
        //else if (temp < startpos + length) startpos -= length;
    }
}