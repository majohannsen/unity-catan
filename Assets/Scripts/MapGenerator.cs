using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    public Tilemap TileMap;
    public int MapSizeX = 7;
    public int MapSizeY = 5;

    TileGenerator tileGenerator;

    private void Awake()
    {
        tileGenerator = GetComponent<TileGenerator>();
    }

    public void FillHexagonalMap(int rounds)
    {
        Vector3Int pos = new Vector3Int(0, 0, 0);
        TileMap.SetTile(pos, tileGenerator.getRandomRessource());

        for (int i = 1; i <= rounds; i++)
        {
            pos = TopLeftAdjacentPosition(pos);

            for (int j = 0; j < i; j++)
            {
                pos = RightAdjacentPosition(pos);
                TileMap.SetTile(pos, tileGenerator.getRandomRessource());
            }
            for (int j = 0; j < i; j++)
            {
                pos = BottomRightAdjacentPosition(pos);
                TileMap.SetTile(pos, tileGenerator.getRandomRessource());
            }
            for (int j = 0; j < i; j++)
            {
                pos = BottomLeftAdjacentPosition(pos);
                TileMap.SetTile(pos, tileGenerator.getRandomRessource());
            }
            for (int j = 0; j < i; j++)
            {
                pos = LeftAdjacentPosition(pos);
                TileMap.SetTile(pos, tileGenerator.getRandomRessource());
            }
            for (int j = 0; j < i; j++)
            {
                pos = TopLeftAdjacentPosition(pos);
                TileMap.SetTile(pos, tileGenerator.getRandomRessource());
            }
            for (int j = 0; j < i; j++)
            {
                pos = TopRightAdjacentPosition(pos);
                TileMap.SetTile(pos, tileGenerator.getRandomRessource());
            }
        }
    }

    public void FillRectangleMap()
    {
        Vector3Int pos = new Vector3Int(-MapSizeX / 2, -MapSizeY / 2, 0);
        for (int i = 0; i < MapSizeX; i++)
        {
            for (int j = 0; j < MapSizeY; j++)
            {
                TileMap.SetTile(pos, tileGenerator.getRandomRessource());
                pos.y++;
            }
            pos.y = -MapSizeY / 2;
            pos.x++;
        }
    }

    Vector3Int RightAdjacentPosition(Vector3Int pos)
    {
        pos.x++;
        return pos;
    }
    Vector3Int LeftAdjacentPosition(Vector3Int pos)
    {
        pos.x--;
        return pos;
    }
    Vector3Int TopRightAdjacentPosition(Vector3Int pos)
    {
        if (pos.y % 2 != 0)
        {
            pos.x++;
        }
        pos.y++;
        return pos;
    }
    Vector3Int BottomRightAdjacentPosition(Vector3Int pos)
    {
        if (pos.y % 2 != 0)
        {
            pos.x++;
        }
        pos.y--;
        return pos;
    }
    Vector3Int TopLeftAdjacentPosition(Vector3Int pos)
    {
        if (pos.y % 2 == 0)
        {
            pos.x--;
        }
        pos.y++;
        return pos;
    }
    Vector3Int BottomLeftAdjacentPosition(Vector3Int pos)
    {
        if (pos.y % 2 == 0)
        {
            pos.x--;
        }
        pos.y--;
        return pos;
    }

}
