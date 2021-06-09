using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GenerateBuildings : MonoBehaviour
{
    public Grid Grid;
    public Tilemap Map;
    public Tile[] StreetTile;
    public Tile SettlementTile;
    public Tile CityTile;
    public int MapSizeX = 7;
    public int MapSizeY = 5;

    float scrollSensitivity = 1.12f;

    // Start is called before the first frame update
    void Start()
    {
    }

    //Update is called once per frame
    void Update()
    {
        Vector3Int gridPos = GetMousePosition();

        if (Input.GetMouseButtonDown(0))
        {
            //streets:
            if (((gridPos.x - 0) % 6 == 0) && ((gridPos.y - 2) % 4 == 0))
            {
                TryPlaceStreet(gridPos, StreetTile[0]);
            }
            else if (((gridPos.x - 3) % 6 == 0) && ((gridPos.y - 0) % 4 == 0))
            {
                TryPlaceStreet(gridPos, StreetTile[0]);
            }
            else if (((gridPos.x - 1) % 6 == 0) && ((gridPos.y + 1) % 4 == 0))
            {
                TryPlaceStreet(gridPos, StreetTile[1]);
            }
            else if (((gridPos.x + 2) % 6 == 0) && ((gridPos.y - 1) % 4 == 0))
            {
                TryPlaceStreet(gridPos, StreetTile[1]);
            }
            else if (((gridPos.x - 1) % 6 == 0) && ((gridPos.y - 1) % 4 == 0))
            {
                TryPlaceStreet(gridPos, StreetTile[2]);
            }
            else if (((gridPos.x + 2) % 6 == 0) && ((gridPos.y + 1) % 4 == 0))
            {
                TryPlaceStreet(gridPos, StreetTile[2]);
            }
            //settlements:
            else if (((gridPos.x - 1) % 6 == 0) && ((gridPos.y - 2) % 4 == 0))
            {
                Map.SetTile(gridPos, SettlementTile);
            }
            else if (((gridPos.x + 1) % 6 == 0) && ((gridPos.y - 2) % 4 == 0))
            {
                Map.SetTile(gridPos, SettlementTile);
            }
            else if (((gridPos.x - 2) % 6 == 0) && (gridPos.y % 4 == 0))
            {
                Map.SetTile(gridPos, SettlementTile);
            }
            else if (((gridPos.x - 4) % 6 == 0) && (gridPos.y % 4 == 0))
            {
                Map.SetTile(gridPos, SettlementTile);
            }

            Debug.Log("created " + Map.GetTile(gridPos).ToString() + " at " + gridPos);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("destroyed " + Map.GetTile(gridPos).ToString());
            Map.SetTile(gridPos, null);
        }

        if (Input.mouseScrollDelta.y > 0 && Camera.main.orthographicSize >= 0.20f)
        {
            Camera.main.orthographicSize /= scrollSensitivity;
        }
        else if (Input.mouseScrollDelta.y < 0 && Camera.main.orthographicSize <= 25)
        {
            Camera.main.orthographicSize *= scrollSensitivity;
        }

    }

    Vector3Int GetMousePosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;
        return Grid.WorldToCell(mouseWorldPos);
    }

    void TryPlaceStreet(Vector3Int pos, Tile Street)
    {
        if (pos.y % 2 == 0 && (
            //rechts oben
            Map.GetTile(new Vector3Int(pos.x + 1, pos.y + 1, 0)) != null ||
            Map.GetTile(new Vector3Int(pos.x - 2, pos.y - 1, 0)) != null ||
            //rechts unten
            Map.GetTile(new Vector3Int(pos.x + 1, pos.y - 1, 0)) != null ||
            Map.GetTile(new Vector3Int(pos.x - 2, pos.y + 1, 0)) != null))
        {
            Map.SetTile(pos, Street);
        }
        else if (pos.y % 2 != 0 && (
            //rechts oben
            Map.GetTile(new Vector3Int(pos.x + 2, pos.y + 1, 0)) != null ||
            Map.GetTile(new Vector3Int(pos.x - 1, pos.y - 1, 0)) != null ||
            //rechts unten
            Map.GetTile(new Vector3Int(pos.x + 2, pos.y - 1, 0)) != null ||
            Map.GetTile(new Vector3Int(pos.x - 1, pos.y + 1, 0)) != null ||
            //waagrecht
            Map.GetTile(new Vector3Int(pos.x, pos.y + 2, 0)) != null ||
            Map.GetTile(new Vector3Int(pos.x, pos.y - 2, 0)) != null))
        {
            Map.SetTile(pos, Street);
        }
    }
}
