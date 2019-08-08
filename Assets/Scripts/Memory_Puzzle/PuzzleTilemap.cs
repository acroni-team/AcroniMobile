using UnityEngine;
using UnityEngine.Tilemaps;

public class PuzzleTilemap : MonoBehaviour
{
    Tilemap tilemap;
    bool collider = false;
    Vector3Int placeAda;

    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collider = true;
        Vector3 ada = collision.gameObject.transform.position;
        placeAda = new Vector3Int(Mathf.FloorToInt(ada.x), Mathf.FloorToInt(ada.y - 2), 0);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        collider = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collider = false;
        anim = 1;
        SetColorArround(placeAda, 0);
    }

    float anim = 1;
    private void Update()
    {
        if (collider)
        {
            anim = anim - (anim!=0? 0.03f: 0);
            SetColorArround(placeAda, anim);
        }
    }
    
    public void SetColorArround(Vector3Int place, float anime)
    {
        if (!tilemap.GetColor(place).Equals(new Color(1, 1, 0)))
        {
            tilemap.SetTileFlags(place, TileFlags.None);
            tilemap.SetColor(place, new Color(1, 1, anime));
        }
        foreach (int x in new int[] { -1, 1 })
        {
            int dx = x;
            while (tilemap.HasTile(new Vector3Int(place.x + dx, place.y, place.z))){
                if (!(tilemap.GetColor(new Vector3Int(place.x + dx, place.y, place.z)).Equals(new Color(1, 1, 0))))
                {
                    tilemap.SetTileFlags(new Vector3Int(place.x + dx, place.y, place.z), TileFlags.None);
                    tilemap.SetColor(new Vector3Int(place.x + dx, place.y, place.z), new Color(1, 1, anime));
                }
                dx += x;
            }
        }
    }
}
