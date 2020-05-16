using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private GameObject card;
    public GameObject Card { get { return card; } }

    public Dictionary<GridPosition, TileManager> Tiles { get; set; }

    [SerializeField]
    public List<GameObject> deck;
    public List<GameObject> tempDeck;
    bool toggle = false;
    public int deckIndex = 0;
    public int rotations = 0;

    public List<GameObject> controlledCards;
    public List<GameObject> deadCards;
   
    public void shuffleDeck()
    {

        for (int i = 0; i < deck.Count; i++)
        {
            GameObject temp = deck[i];
            int randomIndex = Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
        for (int i = 0; i < deck.Count; i++)
        {
            deck[i].GetComponent<CardManager>().cardIndex = i;
        }
    }

    public void printDeck()
    {
        foreach (GameObject go in deck)
        {
            Debug.Log(go.name);
        }
    }

    public int[] arrows = { (int)CardArrow.NONE, (int)CardArrow.NONE, (int)CardArrow.NONE, (int)CardArrow.NONE };
    public int[] stats = { 0, 0, 0, 0 };
    // Start is called before the first frame update
    void Start()
    {
        shuffleDeck();
        assignArrows();
      //  Debug.Log("Card at 1: " + deck[1].name);
        //deck.RemoveAt(1);
        Debug.Log("Cards in Deck");
        printDeck();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void removeFromDeck(int cardIndex)
    {
        deck.RemoveAt(cardIndex);
    }
    public void transferToList(List<GameObject> list, int cardIndex)
    {
        GameObject temp = deck[cardIndex];
        list.Add(temp);
        deck.RemoveAt(cardIndex);
    }
    public void addToControlled(GameObject card)
    {
        controlledCards.Add(card);
    }
    public void addToDead(GameObject card)
    {
        deadCards.Add(card);
    }
    /*Assigns the current card's arrows, only a few are loaded becaues there's a lot of cards*/
    public void assignArrows()
    {
        string cardName = deck[deckIndex].name;
        //Debug.Log("Assigning arrows for " + cardName);

        int lastStringIndex = 0;
        //there are some objectNames that have "(clone)" in it, so we'll choose the correct substring
        //by taking out everything after the actual card name
        //this let's us use a switch statement
        if (cardName.Contains("("))
        {
            lastStringIndex = cardName.IndexOf("(");
            cardName = cardName.Substring(0, lastStringIndex);
        }

        switch (cardName)
        {
            case "Democrats":
                arrows[0] = (int)CardArrow.NONE;
                arrows[1] = (int)CardArrow.IN;
                arrows[2] = (int)CardArrow.OUT;
                arrows[3] = (int)CardArrow.OUT;

                stats[(int)CardStatEnums.Power] = 5;
                stats[(int)CardStatEnums.Transferable] = 0;
                stats[(int)CardStatEnums.Resistance] = 4;
                stats[(int)CardStatEnums.Income] = 3;
                break;
            case "Republicans":
                arrows[0] = (int)CardArrow.OUT;
                arrows[1] = (int)CardArrow.IN;
                arrows[2] = (int)CardArrow.OUT;
                arrows[3] = (int)CardArrow.OUT;

                stats[(int)CardStatEnums.Power] = 4;
                stats[(int)CardStatEnums.Transferable] = 0;
                stats[(int)CardStatEnums.Resistance] = 4;
                stats[(int)CardStatEnums.Income] = 4;
                break;
            case "Flat_Earthers":
                arrows[0] = (int)CardArrow.NONE;
                arrows[1] = (int)CardArrow.IN;
                arrows[2] = (int)CardArrow.NONE;
                arrows[3] = (int)CardArrow.OUT;

                stats[(int)CardStatEnums.Power] = 1;
                stats[(int)CardStatEnums.Transferable] = 0;
                stats[(int)CardStatEnums.Resistance] = 2;
                stats[(int)CardStatEnums.Income] = 1;
                break;
            case "Hollywood":
                arrows[0] = (int)CardArrow.NONE;
                arrows[1] = (int)CardArrow.OUT;
                arrows[2] = (int)CardArrow.OUT;
                arrows[3] = (int)CardArrow.IN;

                stats[(int)CardStatEnums.Power] = 2;
                stats[(int)CardStatEnums.Transferable] = 0;
                stats[(int)CardStatEnums.Resistance] = 0;
                stats[(int)CardStatEnums.Income] = 5;
                break;
            case "Hackers":
                arrows[0] = (int)CardArrow.OUT;
                arrows[1] = (int)CardArrow.IN;
                arrows[2] = (int)CardArrow.NONE;
                arrows[3] = (int)CardArrow.NONE;

                stats[(int)CardStatEnums.Power] = 1;
                stats[(int)CardStatEnums.Transferable] = 1;
                stats[(int)CardStatEnums.Resistance] = 4;
                stats[(int)CardStatEnums.Income] = 2;
                break;
            case "Pentagon":
                arrows[0] = (int)CardArrow.OUT;
                arrows[1] = (int)CardArrow.IN;
                arrows[2] = (int)CardArrow.OUT;
                arrows[3] = (int)CardArrow.OUT;

                stats[(int)CardStatEnums.Power] = 6;
                stats[(int)CardStatEnums.Transferable] = 0;
                stats[(int)CardStatEnums.Resistance] = 6;
                stats[(int)CardStatEnums.Income] = 2;
                break;
            case "Recyclers":
                arrows[0] = (int)CardArrow.NONE;
                arrows[1] = (int)CardArrow.IN;
                arrows[2] = (int)CardArrow.NONE;
                arrows[3] = (int)CardArrow.OUT;

                stats[(int)CardStatEnums.Power] = 2;
                stats[(int)CardStatEnums.Transferable] = 0;
                stats[(int)CardStatEnums.Resistance] = 2;
                stats[(int)CardStatEnums.Income] = 3;
                break;
            case "Texas":
                arrows[0] = (int)CardArrow.OUT;
                arrows[1] = (int)CardArrow.OUT;
                arrows[2] = (int)CardArrow.NONE;
                arrows[3] = (int)CardArrow.IN;

                stats[(int)CardStatEnums.Power] = 6;
                stats[(int)CardStatEnums.Transferable] = 0;
                stats[(int)CardStatEnums.Resistance] = 6;
                stats[(int)CardStatEnums.Income] = 4;
                break;
            case "The_Mafia":
                arrows[0] = (int)CardArrow.OUT;
                arrows[1] = (int)CardArrow.IN;
                arrows[2] = (int)CardArrow.OUT;
                arrows[3] = (int)CardArrow.OUT;

                stats[(int)CardStatEnums.Power] = 7;
                stats[(int)CardStatEnums.Transferable] = 0;
                stats[(int)CardStatEnums.Resistance] = 7;
                stats[(int)CardStatEnums.Income] = 6;
                break;
            case "Trekkies":
                arrows[0] = (int)CardArrow.NONE;
                arrows[1] = (int)CardArrow.IN;
                arrows[2] = (int)CardArrow.NONE;
                arrows[3] = (int)CardArrow.NONE;

                stats[(int)CardStatEnums.Power] = 0;
                stats[(int)CardStatEnums.Transferable] = 0;
                stats[(int)CardStatEnums.Resistance] = 4;
                stats[(int)CardStatEnums.Income] = 3;
                break;
            case "Video_Games":
                arrows[0] = (int)CardArrow.NONE;
                arrows[1] = (int)CardArrow.IN;
                arrows[2] = (int)CardArrow.OUT;
                arrows[3] = (int)CardArrow.NONE;

                stats[(int)CardStatEnums.Power] = 2;
                stats[(int)CardStatEnums.Transferable] = 0;
                stats[(int)CardStatEnums.Resistance] = 3;
                stats[(int)CardStatEnums.Income] = 7;
                break;
            case "Moonies":
                arrows[0] = (int)CardArrow.OUT;
                arrows[1] = (int)CardArrow.NONE;
                arrows[2] = (int)CardArrow.NONE;
                arrows[3] = (int)CardArrow.IN;

                stats[(int)CardStatEnums.Power] = 2;
                stats[(int)CardStatEnums.Transferable] = 0;
                stats[(int)CardStatEnums.Resistance] = 4;
                stats[(int)CardStatEnums.Income] = 3;
                break;
            case "California":
                arrows[0] = (int)CardArrow.OUT;
                arrows[1] = (int)CardArrow.NONE;
                arrows[2] = (int)CardArrow.OUT;
                arrows[3] = (int)CardArrow.IN;

                stats[(int)CardStatEnums.Power] = 5;
                stats[(int)CardStatEnums.Transferable] = 0;
                stats[(int)CardStatEnums.Resistance] = 4;
                stats[(int)CardStatEnums.Income] = 5;
                break;

            case "F.B.I":
                arrows[0] = (int)CardArrow.OUT;
                arrows[1] = (int)CardArrow.IN;
                arrows[2] = (int)CardArrow.OUT;
                arrows[3] = (int)CardArrow.NONE;

                stats[(int)CardStatEnums.Power] = 4;
                stats[(int)CardStatEnums.Transferable] = 2;
                stats[(int)CardStatEnums.Resistance] = 6;
                stats[(int)CardStatEnums.Income] = 0;
                break;

            case "C.I.A":
                arrows[0] = (int)CardArrow.OUT;
                arrows[1] = (int)CardArrow.IN;
                arrows[2] = (int)CardArrow.OUT;
                arrows[3] = (int)CardArrow.OUT;

                stats[(int)CardStatEnums.Power] = 6;
                stats[(int)CardStatEnums.Transferable] = 4;
                stats[(int)CardStatEnums.Resistance] = 5;
                stats[(int)CardStatEnums.Income] = 0;
                break;

            case "Antiwar_Activists":
                arrows[0] = (int)CardArrow.NONE;
                arrows[1] = (int)CardArrow.NONE;
                arrows[2] = (int)CardArrow.NONE;
                arrows[3] = (int)CardArrow.IN;

                stats[(int)CardStatEnums.Power] = 0;
                stats[(int)CardStatEnums.Transferable] = 0;
                stats[(int)CardStatEnums.Resistance] = 3;
                stats[(int)CardStatEnums.Income] = 1;
                break;

            case "American_Autoduel_Association":
                arrows[0] = (int)CardArrow.NONE;
                arrows[1] = (int)CardArrow.OUT;
                arrows[2] = (int)CardArrow.NONE;
                arrows[3] = (int)CardArrow.IN;
                stats[(int)CardStatEnums.Power] = 1;
                stats[(int)CardStatEnums.Transferable] = 0;
                stats[(int)CardStatEnums.Resistance] = 5;
                stats[(int)CardStatEnums.Income] = 1;
                break;

            case "The_UFOs":
            case "The_Network":
            case "The_Society_of_Assassins":
            case "The_Discordian_Society":
            case "The_Servants_of_Cthulu":
            case "The_Gnomes_of_Zurich":
            case "The_Bavarian_Illuminati":
            case "The_Bermuda_Triangle":
                arrows[0] = (int)CardArrow.OUT;
                arrows[1] = (int)CardArrow.OUT;
                arrows[2] = (int)CardArrow.OUT;
                arrows[3] = (int)CardArrow.OUT;

                //the below stats are specific to UFOs only
                stats[(int)CardStatEnums.Power] = 6;
                stats[(int)CardStatEnums.Transferable] = 6;
                stats[(int)CardStatEnums.Resistance] = 0;
                stats[(int)CardStatEnums.Income] = 8;
                break;

            default:
                Debug.Log("No card name found!");
                break;
        }
        //Debug.Log("After assigning arrows: ");
        //foreach (int i in arrows)
        //{
        //    Debug.Log(i);
        //}
        //Debug.Log("-------------------");

    }

    /*Reassigns the card arrows when it is rotated*/
    public void reassignArrows()
    {

        int size = arrows.Length;
        int temp = arrows[size - 1];

        for (int i = size - 1; i > 0; i--)
        {
            arrows[i] = arrows[i - 1];
        }
        arrows[0] = temp;
        /*
        Debug.Log("printing arrows after rotating");
        foreach (int i in arrows)
        {
            Debug.Log(i);
        } */
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(5, 30, 200, 40), "Give Money"))
        {
            foreach(KeyValuePair<GridPosition,TileManager> t in Tiles)
            {
                if(!(t.Value.Card is null))
                {
                    t.Value.Card.GetComponent<CardManager>().updateTreasury();
                }
            }
        }
        if(GUI.Button(new Rect(5, 70, 200, 40), "Toggle Card Placing"))
        {
            if (!toggle)
            {
                toggle = true;
                for(int i = 0; i < deck.Count; i++)
                {
                    tempDeck.Add(deck[i]);
                }
                while(deck.Count != 0)
                {
                    deck.RemoveAt(0);
                }
            }
            else
            {
                toggle = false;
                for (int i = 0; i < tempDeck.Count; i++)
                {
                    deck.Add(tempDeck[i]);
                }
                while (tempDeck.Count != 0)
                {
                    tempDeck.RemoveAt(0);
                }
            }
        }
    }
}
