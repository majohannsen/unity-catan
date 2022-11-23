using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileGenerator : MonoBehaviour
{
    public CatanTile[] ressourceTiles;
    public CatanTile desertTile;
    public CatanTile waterTile;
    
    public CatanTile getRandomRessource()
    {
        return ressourceTiles[(int)(Random.value * ressourceTiles.Length)];
    }

    public CatanTile getDesert() {
        return desertTile;
    }

    public CatanTile getWater() {
        return waterTile;
    }
}
