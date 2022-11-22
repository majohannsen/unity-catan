using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapEditor : MonoBehaviour
{
    public Grid Grid;
    public Tilemap TileMap;
    public bool EnableTileChanging = true;

    private Vector3Int PrevMousePos;
    private TileGenerator tileGenerator;

    private void Awake()
    {
        tileGenerator = GetComponent<TileGenerator>();
    }

    void Start()
    {
        PrevMousePos = GetMousePosition();
    }

    //Update is called once per frame
    void Update()
    {
        Vector3Int mousePos = GetMousePosition();

        if ((Input.GetMouseButtonDown(0) || (Input.GetMouseButton(0) && mousePos != PrevMousePos)) && EnableTileChanging)
        {
            PrevMousePos = mousePos;
            TileMap.SetTile(mousePos, tileGenerator.getRandomRessource());
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
