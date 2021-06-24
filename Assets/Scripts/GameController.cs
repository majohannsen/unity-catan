using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class GameController : MonoBehaviour
{
    public Grid BuildingsStreetsGrid;
    public Tilemap BuildingsStreetsMap;
    public Tile[] StreetTile;
    public Tile SettlementTile;
    public Tile CityTile;
    public int MapSizeX = 7;
    public int MapSizeY = 5;

    public int freePlacement = 2;

    public bool EnablePlacement = true;
    public bool EnableDeletion = false;
    public bool EnableZoom = true;

    float scrollSensitivity = 1.12f;
    TMP_Text Text;

    // Start is called before the first frame update
    void Start()
    {
        Text = GameObject.FindGameObjectWithTag("UI Text").GetComponent<TMP_Text>();
        Text.text = "Free Placement: " + freePlacement; 
    }

    //Update is called once per frame
    void Update()
    {
        Vector3Int gridPos = GetMousePosition();

        if (Input.GetMouseButtonDown(0) && EnablePlacement)
        {
            //check if the click is on grid
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
                TryPlaceSettlement(gridPos, SettlementTile);
            }
            else if (((gridPos.x + 1) % 6 == 0) && ((gridPos.y - 2) % 4 == 0))
            {
                TryPlaceSettlement(gridPos, SettlementTile);
            }
            else if (((gridPos.x - 2) % 6 == 0) && (gridPos.y % 4 == 0))
            {
                TryPlaceSettlement(gridPos, SettlementTile);
            }
            else if (((gridPos.x - 4) % 6 == 0) && (gridPos.y % 4 == 0))
            {
                TryPlaceSettlement(gridPos, SettlementTile);
            }
        }

        if (Input.GetMouseButtonDown(1) && EnableDeletion)
        {
            try
            {
                Debug.Log("destroyed " + BuildingsStreetsMap.GetTile(gridPos).ToString());
                BuildingsStreetsMap.SetTile(gridPos, null);
            }
            catch { }
        }

        if (EnableZoom)
        {
            if (Input.mouseScrollDelta.y > 0 && Camera.main.orthographicSize >= 0.20f)
            {
                Camera.main.orthographicSize /= scrollSensitivity;
            }
            else if (Input.mouseScrollDelta.y < 0 && Camera.main.orthographicSize <= 25)
            {
                Camera.main.orthographicSize *= scrollSensitivity;
            }
        }

    }

    Vector3Int GetMousePosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;
        return BuildingsStreetsGrid.WorldToCell(mouseWorldPos);
    }

    void TryPlaceStreet(Vector3Int pos, Tile Street)
    {
        //check if ohter streets are adjacent
        if (pos.y % 2 == 0 && (
            //rechts oben
            BuildingsStreetsMap.GetTile(new Vector3Int(pos.x + 1, pos.y + 1, 0)) != null ||
            BuildingsStreetsMap.GetTile(new Vector3Int(pos.x - 2, pos.y - 1, 0)) != null ||
            //rechts unten
            BuildingsStreetsMap.GetTile(new Vector3Int(pos.x + 1, pos.y - 1, 0)) != null ||
            BuildingsStreetsMap.GetTile(new Vector3Int(pos.x - 2, pos.y + 1, 0)) != null))
        {
            BuildingsStreetsMap.SetTile(pos, Street);
        }
        else if (pos.y % 2 != 0 && (
            //rechts oben
            BuildingsStreetsMap.GetTile(new Vector3Int(pos.x + 2, pos.y + 1, 0)) != null ||
            BuildingsStreetsMap.GetTile(new Vector3Int(pos.x - 1, pos.y - 1, 0)) != null ||
            //rechts unten
            BuildingsStreetsMap.GetTile(new Vector3Int(pos.x + 2, pos.y - 1, 0)) != null ||
            BuildingsStreetsMap.GetTile(new Vector3Int(pos.x - 1, pos.y + 1, 0)) != null ||
            //waagrecht
            BuildingsStreetsMap.GetTile(new Vector3Int(pos.x, pos.y + 2, 0)) != null ||
            BuildingsStreetsMap.GetTile(new Vector3Int(pos.x, pos.y - 2, 0)) != null))
        {
            BuildingsStreetsMap.SetTile(pos, Street);
        }
        //check if buildings are adjacent ...
    }

    void TryPlaceSettlement(Vector3Int pos, Tile Settlement)
    {
        //check if Settlement is allowed to be placed ...(other settlemens to close)
        if (freePlacement > 0)
        {
            if (BuildingsStreetsMap.GetTile(pos).name == Settlement.name)
            {
                Debug.Log("I wont override a settlement");
                return;
            }
            BuildingsStreetsMap.SetTile(pos, Settlement);
            Debug.Log("created " + BuildingsStreetsMap.GetTile(pos).ToString() + " at " + pos);
            freePlacement--;
            Text.text = "Free Placement: " + freePlacement;
        }
        //check if Streets are adjacent ...
    }
}
