using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileGenerator : MonoBehaviour
{
    public CatanTile[] ressourceTiles;
    public CatanTile desertTile;
    public CatanTile waterTile;
    
    public Tile getRandomRessource()
    {
        return ressourceTiles[(int)(Random.value * ressourceTiles.Length)];
    }

    public Tile getDesert() {
        return desertTile;
    }

    public Tile getWater() {
        return waterTile;
    }
}
