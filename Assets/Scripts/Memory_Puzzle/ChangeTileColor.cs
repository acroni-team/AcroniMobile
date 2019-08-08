using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChangeTileColor : MonoBehaviour
{
    private WorldTile _tile;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 ada = collision.gameObject.transform.position;
        var pontinho = new Vector3Int(Mathf.FloorToInt(ada.x), Mathf.FloorToInt(ada.y - 2), 0);
        Dictionary<Vector3, WorldTile> tiles = GameTiles.instance.tiles;

        if (tiles.TryGetValue(pontinho, out _tile))
        {
            _tile.TilemapMember.SetTileFlags(_tile.LocalPlace, TileFlags.None);
            _tile.TilemapMember.SetColor(_tile.LocalPlace, Color.blue);
        }
    }
}
