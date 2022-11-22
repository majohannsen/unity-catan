using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class CatanTile : Tile
{
    public Sprite[] sprites;
    
    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        Random.State state = Random.state;
        Random.InitState(position.GetHashCode());
        tileData.sprite = sprites[(int)(Random.value * sprites.Length)];
        Random.state = state;
    }
}
