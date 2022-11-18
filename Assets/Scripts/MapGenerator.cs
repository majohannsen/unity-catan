using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    public Grid Grid;
    public Tilemap TileMap;
    public Tile[] LandTile;
    public HexagonalRuleTile hexagonalRuleTile;
    public int MapSizeX = 7;
    public int MapSizeY = 5;
    public bool EnableTileChanging = false;

    TileGenerator tileGenerator;
    Vector3Int PrevMousePos;

    // Start is called before the first frame update
    void Start()
    {
        tileGenerator = GetComponent<TileGenerator>();

        PrevMousePos = GetMousePosition();

        FillRectangleMap();

        // Vector3Int pos = new Vector3Int(3, 0, 0);
        // for (int i = 0; i < 7; i++)
        // {
        //     TileMap.SetTile(pos, tileGenerator.getLandTile());
        //     pos = LeftAdjacentPosition(pos);
        // }
    }

    void FillRectangleMap()
    {
        Vector3Int pos = new Vector3Int(-MapSizeX / 2, -MapSizeY / 2, 0);
        for (int i = 0; i < MapSizeX; i++)
        {
            for (int j = 0; j < MapSizeY; j++)
            {
                TileMap.SetTile(pos, tileGenerator.getLandTile());
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

    //Update is called once per frame
    void Update()
    {
        Vector3Int mousePos = GetMousePosition();

        if ((Input.GetMouseButtonDown(0) || (Input.GetMouseButton(0) && mousePos != PrevMousePos)) && EnableTileChanging)
        {
            PrevMousePos = mousePos;
            TileMap.SetTile(mousePos, tileGenerator.getLandTile());
            Debug.Log("created " + TileMap.GetTile(mousePos).ToString());
        }

        if ((Input.GetMouseButtonDown(1) || (Input.GetMouseButton(1) && mousePos != PrevMousePos)) && EnableTileChanging)
        {
            try
            {
                PrevMousePos = mousePos;
                Debug.Log("destroyed " + TileMap.GetTile(mousePos).ToString());
                TileMap.SetTile(mousePos, null);
            }
            catch { }
        }

    }

    Vector3Int GetMousePosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;
        return Grid.WorldToCell(mouseWorldPos);
    }
}
