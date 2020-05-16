using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TileManager : MonoBehaviour
{
    [SerializeField]
    GameObject illuminatiCard;
    public GridPosition position { get; private set; }

    private bool occupied; 
    public bool Occupied { get { return occupied; } set { occupied = value; } }

    private GameObject card;
    public GameObject Card { get { return card; } set { card = value; } }

    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setup (GridPosition pos, Vector3 worldPos)
    {
        //initialize the position in the grid
        position = pos;
        //initialize the position in the actual world
        transform.position = worldPos;
      /*  Debug.Log("Tile placed at: " + position.xPosition+", "+position.yPosition);*/
        occupied = false;
        card = null;
    }

    public void OnMouseOver()
    {
        //some debug statements to analyze each tile
        
            Debug.Log("Occupied?: " + occupied + "   Card: " + card);
            Debug.Log("Mousing over: " + position.xPosition + ", " + position.yPosition);
            if (!(card is null)) { 
              /*  foreach (int i in card.GetComponent<CardManager>().arrows)
                {
                    Debug.Log(i);
                }
                */
                foreach (int i in card.GetComponent<CardManager>().stats)
                {
                    Debug.Log(i);
                }
                Debug.Log("-----------------------------------------------------------------");
            }
            
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Clicked on: " + position.xPosition + ", " + position.yPosition);
            if (GameManager.Instance.deck.Count != 0) {
                if (placeCard())
                {
                    GameManager.Instance.rotations = 0;
                }
            }
        }
        else if (Input.GetMouseButtonDown(1) && GameManager.Instance.deck.Count != 0)
        {
            GameManager.Instance.rotations++;
            GameManager.Instance.reassignArrows();
        }
    }

    private bool placeCard()
    {
        if (!occupied && validatePlacement(GameManager.Instance.deck[GameManager.Instance.deckIndex]))
        {
            occupied = true;
            Debug.Log("Placing a card");

            //assigns the tile's current card
            card = Instantiate(GameManager.Instance.deck[GameManager.Instance.deckIndex], new Vector3(transform.position.x + (float)10.24, transform.position.y - (float)10.24, 0),
                Quaternion.Euler(Vector3.forward * -90 * (GameManager.Instance.rotations %4)));
            
            //this assigns the arrows for the card as soon as it is placed on the board, now the cardManager has that information
            card.GetComponent<CardManager>().assignStats();

            GameManager.Instance.addToControlled(card);            

            GameManager.Instance.removeFromDeck(GameManager.Instance.deckIndex) ;

           /* for(int i=0; i < GameManager.Instance.stats.Length; i++)
            {
                GameManager.Instance.stats[i] = 0;
            }*/
            Debug.Log("Controlled Cards: ");
            foreach( GameObject go in GameManager.Instance.controlledCards)
            {
                Debug.Log(go.name);
            }
            Debug.Log("Cards in Deck: ");
            GameManager.Instance.printDeck();
            
            //increments to the next card in the Deck
            GameManager.Instance.deckIndex++;

            //allows for cycling through the deck
            if(GameManager.Instance.deckIndex >= GameManager.Instance.deck.Count)
            {
                GameManager.Instance.deckIndex = 0;
            }
            if (GameManager.Instance.deck.Count == 0)
            {
                return true;
            }
            //this assigns the arrows for the NEW card coming up
            GameManager.Instance.assignArrows();
            return true;
        }
        else
        {
            Debug.Log("Not placing a card!");
            return false;
        }   
        
    }


    public bool validatePlacement(GameObject card)
    {
        int maxTile= (int)Math.Sqrt(GameManager.Instance.Tiles.Count);
        Dictionary<GridPosition, TileManager> tempDict = GameManager.Instance.Tiles;
        int leftTile = position.xPosition - 1;
        int rightTile = position.xPosition + 1;
        int upTile = position.yPosition - 1;
        int downTile = position.yPosition + 1;
        GridPosition left = null ;
        GridPosition down = null;
        GridPosition up= null;
        GridPosition right = null; ;

        //had to perform these annoying gymnastics becaue the Dictionary wasn't cooperating?
        foreach(KeyValuePair<GridPosition,TileManager> t in tempDict)
        {
            if(t.Key.xPosition== leftTile && t.Key.yPosition == position.yPosition)
            {
                left = t.Key;
            }
            else if(t.Key.xPosition== rightTile && t.Key.yPosition == position.yPosition)
            {
                right = t.Key;
            }
            else if(position.xPosition == t.Key.xPosition && t.Key.yPosition == upTile)
            {
                up = t.Key;
            }
            else if(position.xPosition== t.Key.xPosition && t.Key.yPosition == downTile)
            {
                down = t.Key;
            }
        }

        if (leftTile >= 0)
        {
            if (!(tempDict[left].card is null))
            {
                int[] tempArr = tempDict[left].card.GetComponent<CardManager>().arrows;

                if ((tempArr[1]==1 && GameManager.Instance.arrows[3] == 2)
                    || (tempArr[1] == 2 && GameManager.Instance.arrows[3] == 1))
                {
                    return true;
                }
            }
        }

        if (rightTile <= maxTile)
        {
            if (!(tempDict[right].card is null))
            {
                int[] tempArr = tempDict[right].card.GetComponent<CardManager>().arrows;

                if ((tempArr[3] == 1 && GameManager.Instance.arrows[1] == 2)||
                   (tempArr[3] == 2 && GameManager.Instance.arrows[1] == 1))
                {
                    return true;
                }
            }
        }

        if (upTile >= 0)
        {
            if (!(tempDict[up].card is null)) { 
                int[] tempArr = tempDict[up].card.GetComponent<CardManager>().arrows;

                if ((tempArr[2] ==1 && GameManager.Instance.arrows[0] == 2)||
                     (tempArr[2] == 2 && GameManager.Instance.arrows[0] == 1))
                {
                    return true;
                }
            } 
        }

        if (downTile<= maxTile)
        {
            if (!(tempDict[down].card is null))
            {
                int[] tempArr = tempDict[down].card.GetComponent<CardManager>().arrows;
                Debug.Log("testing up and down tile"+tempDict[down].card.GetComponent<CardManager>().name);

                if ((tempArr[0] ==1 && GameManager.Instance.arrows[2] == 2) ||
                   (tempArr[0] == 2 && GameManager.Instance.arrows[2] == 1))
                {
                    Debug.Log("tempArr[0]= " + tempArr[0] + " cardBot= " + card.GetComponent<CardManager>().arrows[2]);
                    return true;
                }
            }
        }

        return false;
    }
}

