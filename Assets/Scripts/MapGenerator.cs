using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GenerateMap : MonoBehaviour
{
    public Grid Grid;
    public Tilemap Map;
    public Tile[] LandTile;
    public int MapSizeX = 7;
    public int MapSizeY = 5;

    Vector3Int PrevMousePos;

    // Start is called before the first frame update
    void Start()
    {
        PrevMousePos = GetMousePosition();

        //Vector3Int pos = new Vector3Int(-MapSizeX / 2, -MapSizeY / 2, 0);

        //for (int i = 0; i < MapSizeX; i++)
        //{
        //    for (int j = 0; j < MapSizeY; j++)
        //    {
        //        Map.SetTile(pos, LandTile);
        //        pos.y++;
        //    }
        //    pos.y = -MapSizeY / 2;
        //    pos.x++;
        //}
    }

    //Update is called once per frame
    void Update()
    {
        Vector3Int mousePos = GetMousePosition();

        if (Input.GetMouseButtonDown(0) || (Input.GetMouseButton(0) && mousePos != PrevMousePos))
        {
            PrevMousePos = mousePos;
            Map.SetTile(mousePos, LandTile[(int)(Random.value * 6)]);
            Debug.Log("created " + Map.GetTile(mousePos).ToString());
        }

        if (Input.GetMouseButtonDown(1) || (Input.GetMouseButton(1) && mousePos != PrevMousePos))
        {
            PrevMousePos = mousePos;
            Debug.Log("destroyed " + Map.GetTile(mousePos).ToString());
            Map.SetTile(mousePos, null);
        }

    }

    Vector3Int GetMousePosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;
        return Grid.WorldToCell(mouseWorldPos);
    }
}
