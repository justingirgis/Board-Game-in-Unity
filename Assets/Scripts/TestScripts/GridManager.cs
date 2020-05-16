using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    private int rows = 1;
    [SerializeField]
    private int cols = 1;
    [SerializeField]
    private float tileSize = 1;
    [SerializeField]
    private string spriteName = "wood_resized";
    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
        Debug.Log("Generating Grid");
    }

    private void GenerateGrid()
    {
        GameObject myTile = (GameObject)Instantiate(Resources.Load(spriteName));
        for(int r = 0; r < rows; r++)
        {
            for(int c = 0; c < cols; c++)
            {
                GameObject tile = (GameObject)Instantiate(myTile, transform);
                float positionX = c * tileSize;
                float positionY = r * -tileSize;

                tile.transform.position = new Vector2(positionX, positionY);
            }
        }

        Destroy(myTile);

        float gridH = cols * tileSize;
        float gridW = rows * tileSize;
        //transform.position = new Vector2((-gridW/2) + (tileSize / 2), (gridH/2) - (tileSize / 2));
        transform.position = new Vector2(-gridH/2 - (tileSize/4) + (tileSize/20),gridW/2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
