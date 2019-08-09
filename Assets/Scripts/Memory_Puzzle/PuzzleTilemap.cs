using UnityEngine;
using UnityEngine.Tilemaps;
using System.Threading;

public class PuzzleTilemap : MonoBehaviour
{
    //public variables
    public Vector3Int[] locals;

    //private variables
    Tilemap tilemap;
    bool isColliding = false;
    Vector3Int placeAda;

    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isColliding = true;
        Vector3 ada = collision.gameObject.transform.position;
        placeAda = new Vector3Int(Mathf.FloorToInt(ada.x), Mathf.FloorToInt(ada.y - 2), 0);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isColliding = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isColliding = false;
        anim = 1;
        SetColorArround(placeAda, 0);
    }

    [HideInInspector]
    public bool startShow = false;
    int tile = 0;
    float anim = 1;
    private void FixedUpdate()
    {
        if (isColliding)
        {
            anim = (anim > 0 ? anim - 0.025f : 0);
            SetColorArround(placeAda, anim);
        }
        if (startShow)
        {
            if (tile == locals.Length)
            {
                Clear();
                startShow = false;
            }
            Vector3Int position = locals[tile];
            
            if (!(tilemap.GetColor(new Vector3Int(position.x, position.y, position.z)).Equals(new Color(1, 1, 0))))
            {
                anim = (anim > 0 ? anim - 0.025f : 0);
                SetColorArround(position, anim);
            }
            else
            {
                anim = 1;
                if (tile < locals.Length)
                    tile++;
            }
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
            while (tilemap.HasTile(new Vector3Int(place.x + dx, place.y, place.z)))
            {
                if (!(tilemap.GetColor(new Vector3Int(place.x + dx, place.y, place.z)).Equals(new Color(1, 1, 0))))
                {
                    tilemap.SetTileFlags(new Vector3Int(place.x + dx, place.y, place.z), TileFlags.None);
                    tilemap.SetColor(new Vector3Int(place.x + dx, place.y, place.z), new Color(1, 1, anime));
                }
                dx += x;
            }
        }
    }

    //public void Clear()
    //{
    //    foreach (Vector3Int local in locals)
    //    {
    //        tilemap.SetColor(local, Color.);
    //        tilemap.SetTileFlags(local, TileFlags.None);
    //        int dx = 1;
    //        while (tilemap.HasTile(new Vector3Int(local.x + dx, local.y, local.z)))
    //        {
    //                tilemap.SetTileFlags(new Vector3Int(local.x + dx, local.y, local.z), TileFlags.None);
    //                tilemap.SetColor(new Vector3Int(local.x + dx, local.y, local.z), Color.clear);
    //            dx++;
    //        }
    //    }
    //}

    public void Clear()
    {
        foreach (Vector3Int local in locals)
        {
            tilemap.SetTileFlags(local, TileFlags.None);
            tilemap.SetColor(local, new Color(1, 1, 1));
            int dx = 1;
            while (tilemap.HasTile(new Vector3Int(local.x + dx, local.y, local.z)))
            {
                tilemap.SetTileFlags(new Vector3Int(local.x + dx, local.y, local.z), TileFlags.None);
                tilemap.SetColor(new Vector3Int(local.x + dx, local.y, local.z), new Color(1, 1, 1));
                dx++;
            }
        }
    }
}
