using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public struct CatanTileData
{
    public CatanTileData(int numberChip, bool revealed) {
        this.numberChip = numberChip;
        this.revealed = revealed;
    }
    public int numberChip;
    public bool revealed;

}

public class MapManager : MonoBehaviour
{
    public Tilemap tileMap;

    private Dictionary<Vector3Int, CatanTileData> tileDatas = new Dictionary<Vector3Int, CatanTileData>();

    public void SetTile(Vector3Int pos, CatanTile tile) {
        tileMap.SetTile(pos, tile);
        tileDatas.Add(pos, new CatanTileData(-1, true));
    }

    public void revealTile(Vector3Int pos) {
        tileDatas[pos] = new CatanTileData(tileDatas[pos].numberChip, true);
    }

}
