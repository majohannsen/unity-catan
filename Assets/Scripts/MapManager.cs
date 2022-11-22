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

    public Tilemap TileMap;
    private Dictionary<Vector3Int, CatanTileData> tileDatas;

    public void SetTile(Vector3Int pos, Tile tile) {

    }

    public void SetTile(Vector3Int pos, Tile tile, int numberChip, bool revealed) {

    }

    public void EditTile(Vector3Int pos, int numberChip, bool revealed) {

    }

    public void revealTile(Vector3Int pos) {
        tileDatas[pos] = new CatanTileData(tileDatas[pos].numberChip, true);
    }

}
