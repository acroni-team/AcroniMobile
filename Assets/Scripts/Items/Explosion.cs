
using UnityEngine;
using UnityEngine.Tilemaps;

public class Explosion : MonoBehaviour
{
    public GameObject bomba;
    public float radius;
    public float power;
    public Tilemap special_blocks;
    public TileBase explosionAnim;
    public void OnWickDestroy()
    {
        bomba.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        bomba.GetComponent<CircleCollider2D>().isTrigger = true;
        Vector3 explosionPos = bomba.GetComponent<Renderer>().bounds.center;
        try
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPos, 100);
            foreach (Collider2D hit in colliders)
            {
                try
                {
                    if (Mathf.Abs(Vector3.Distance(hit.transform.position, explosionPos)) <= radius)
                    {
                        Vector2 distance = hit.transform.position - explosionPos;
                        if (!(Mathf.Abs(distance.x) < 1)&&hit.name.Equals("Ada"))
                        {
                            Player.getInstance().GetPlayerMovement().StartJumpAnimation();
                            Player.getInstance().GetPlayerMovement().DisableMovement();
                            Player.getInstance().GetPlayerMovement().EnableAddForce();
                        }
                        hit.GetComponent<Rigidbody2D>().AddForce(new Vector2(distance.normalized.x * power * Mathf.Pow(distance.magnitude, -1), distance.normalized.y * power *(float)1.5* Mathf.Pow(distance.magnitude, -1)), ForceMode2D.Impulse);
                    }
                }
                catch (System.Exception) { }
            }
            
            foreach(Vector3 position in special_blocks.cellBounds.allPositionsWithin)
            {
                if (Mathf.Abs(Vector3.Distance(explosionPos, position)) <= radius)
                {
                    var tilePos = special_blocks.WorldToCell(position);
                    special_blocks.SetTile(tilePos, null);
                }
            }
        }
        catch (System.Exception e) { /*Debug.Log(e.Message);*/ }
    }

    public void OnExplosionFinished()
    {
        Destroy(bomba);
    }
    public void OnForceAdded()
    {
        Player.getInstance().GetPlayerMovement().EnableMovement();
    }

    public void PlaySound()
    {
        AudioManager.GetInstance().Play("sfx-explosion");
    }
}

