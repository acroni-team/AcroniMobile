using UnityEngine;

public class ShowLevel : MonoBehaviour
{
    [Range(1,10)]
    public float velocity = 1f;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + velocity/100, transform.position.y, transform.position.z);
    }
}
