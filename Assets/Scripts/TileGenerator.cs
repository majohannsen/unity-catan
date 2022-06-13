using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileGenerator : MonoBehaviour
{
    public Tile[] brickTiles;
    public Tile[] desertTiles;
    public Tile[] oreTiles;
    public Tile[] sheepTiles;
    public Tile[] wheatTiles;
    public Tile[] woodTiles;

    private Tile[][] landTiles;

    private void Start()
    {
        landTiles = new Tile[][] {
            brickTiles,
            desertTiles,
            oreTiles,
            sheepTiles,
            wheatTiles,
            woodTiles
        };
    }

    public Tile getBrickTile()
    {
        return brickTiles[(int)(Random.value * brickTiles.Length)];
    }

    public Tile getDesertTile()
    {
        return desertTiles[(int)(Random.value * desertTiles.Length)];
    }

    public Tile getOreTile()
    {
        return oreTiles[(int)(Random.value * oreTiles.Length)];
    }

    public Tile getSheepTile()
    {
        return sheepTiles[(int)(Random.value * sheepTiles.Length)];
    }

    public Tile getWheatTile()
    {
        return wheatTiles[(int)(Random.value * wheatTiles.Length)];
    }

    public Tile getWoodTile()
    {
        return woodTiles[(int)(Random.value * woodTiles.Length)];
    }

    public Tile getLandTile()
    {
        int randomIndex = (int)(Random.value * landTiles.Length);
        return landTiles[randomIndex][(int)(Random.value * landTiles[randomIndex].Length)];
    }
}
