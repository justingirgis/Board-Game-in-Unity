using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GridManager2 : MonoBehaviour
{
    [SerializeField]
    private GameObject tile1;
    [SerializeField]
    private GameObject tile2;
    [SerializeField]
    private int cols=4;
    [SerializeField]
    private int rows=4;
    [SerializeField]
    private GameObject illuminatiCard;
    private Vector3 centerTile;
    public Dictionary<GridPosition, TileManager> Tiles { get; set; }

    public float tileSize { get { return tile1.GetComponent<SpriteRenderer>().sprite.bounds.size.x; } }
    public float tileSize2 { get { return tile2.GetComponent<SpriteRenderer>().sprite.bounds.size.x; } }

    // Start is called before the first frame update
    void Start()
    {
        //generateField();
        generateFieldWithIlluminati();
        setGameDictionary();
        Camera.main.transform.position = centerTile;
        //generateFieldOfCards();  //this is now obsolete
    }

    public void setGameDictionary()
    {
        GameManager.Instance.Tiles = Tiles;
    }
    /**Even though we generally require that both sprites being used to be have the same size, we use their respective sizes
     * to calculate the cloneTile's position.*/
   
    
private void generateField()
    {
        Tiles = new Dictionary<GridPosition, TileManager>();

        //Access the size of the tile from the sprite being used by spriteRenderer
        Vector3 startPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));

        for (int r = 0; r < rows; r++)//represents the current row
        {
            for (int c = 0; c < cols; c++)//represents the current column
            {
                float cloneSize = 0f;
                GameObject cloneTile = null; //have to initialize as null in order to allow the following cases

                if ((c + r) % 2 == 0)
                {
                    cloneTile = Instantiate(tile1);
                    cloneSize = tileSize;
                }
                else
                {
                    cloneTile = Instantiate(tile2);
                    cloneSize = tileSize2;
                }
                //this creates our tile and assigns a gridPosition to it
                cloneTile.GetComponent<TileManager>().setup(new GridPosition(c, r), new Vector3(startPosition.x + (c * cloneSize), startPosition.y - (r * cloneSize), 0));
                Tiles.Add(new GridPosition(c, r), cloneTile.GetComponent<TileManager>());
            }
        }
    }


    private void generateFieldWithIlluminati()
    {
        Tiles = new Dictionary<GridPosition, TileManager>();

        //Access the size of the tile from the sprite being used by spriteRenderer
        Vector3 startPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));
        int totalTiles = rows * cols;
        float maxPerRowCol = (float)Math.Sqrt(totalTiles);
        //we do minus one to account for the index starting at zero
        float middle = (float)Math.Ceiling(maxPerRowCol / 2) -1 ;

        for (int r = 0; r < rows; r++)//represents the current row
        {
            for (int c = 0; c < cols; c++)//represents the current column
            {
                float cloneSize = 0f;
                GameObject cloneTile = null; //have to initialize as null in order to allow the following cases

                if ((c + r) % 2 == 0)
                {
                    cloneTile = Instantiate(tile1);
                    cloneSize = tileSize;
                }
                else
                {
                    cloneTile = Instantiate(tile2);
                    cloneSize = tileSize2;
                }
                //this creates our tile and assigns a gridPosition to it
                cloneTile.GetComponent<TileManager>().setup(new GridPosition(c, r), new Vector3(startPosition.x + (c * cloneSize), startPosition.y - (r * cloneSize), 0));
                if(r== middle && c == middle)
                {
                    cloneTile.GetComponent<TileManager>().Occupied = true;
                    cloneTile.GetComponent<TileManager>().Card = Instantiate(illuminatiCard, new Vector3(startPosition.x + (c*cloneSize)+(float)10.24, startPosition.y- (c*cloneSize) -(float)10.24, 0), Quaternion.identity);
                    centerTile = new Vector3(startPosition.x + (c * cloneSize) + (float)10.24, startPosition.y - (c * cloneSize) - (float)10.24, -10);
                    //cloneTile.GetComponent<TileManager>().Card = illuminatiCard;
                    //
                    illuminatiCard.GetComponent<CardManager>().arrows[0] = 1;
                    illuminatiCard.GetComponent<CardManager>().arrows[1] = 1;
                    illuminatiCard.GetComponent<CardManager>().arrows[2] = 1;
                    illuminatiCard.GetComponent<CardManager>().arrows[3] = 1;

                    illuminatiCard.GetComponent<CardManager>().stats[0] = 6;
                    illuminatiCard.GetComponent<CardManager>().stats[1] = 6;
                    illuminatiCard.GetComponent<CardManager>().stats[2] = 0;
                    illuminatiCard.GetComponent<CardManager>().stats[3] = 8 ;

                }
                Tiles.Add(new GridPosition(c, r), cloneTile.GetComponent<TileManager>());
            }
        }
    }


    //DONT DELETE THIS YET, I NEED IT

    private void generateFieldOfCards()
     {
         //Access the size of the tile from the sprite being used by spriteRenderer
         Vector3 startPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));

         for (int r = 0; r < rows; r++)//represents the current row
         {
             for (int c = 0; c < cols; c++)//represents the current column
             {
                 float cloneSize = 0f;
                 GameObject cloneTile = null; //have to initialize as null in order to allow the following cases

                 if ((c + r) % 2 == 0)
                 {
                     cloneTile = Instantiate(tile1);
                     cloneSize = tileSize;
                    //next two lines add a california to every other square, (as close to the center as possible)
                    //GameObject tempSprite = (GameObject)Instantiate(Resources.Load("Cards/California"));
                    // tempSprite.transform.position = new Vector3(startPosition.x + (c * cloneSize)  + (cloneSize/2) , startPosition.y - (r * cloneSize) - (cloneSize/2), 0);

                    cloneTile.GetComponent<TileManager>().setup(new GridPosition(c, r), new Vector3(startPosition.x + (c * cloneSize), startPosition.y - (r * cloneSize), 0));

                   // cloneTile.GetComponent<TileManager>().Card = tempSprite;
                   // cloneTile.GetComponent<TileManager>().Occupied = true;
                    

                }
                else
                 {
                     cloneTile = Instantiate(tile2);
                     cloneSize = tileSize2;
                    cloneTile.GetComponent<TileManager>().setup(new GridPosition(c, r), new Vector3(startPosition.x + (c * cloneSize), startPosition.y - (r * cloneSize), 0));

                }
                //this creates our tile and assigns a gridPosition to it
            }
         }
     }
     
     
    // Update is called once per frame
    void Update()
    {

    }
}
