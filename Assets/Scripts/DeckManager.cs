using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;

public class DeckManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    List<GameObject> deck;
    
    void Start()
    {
        //printDeck();
        Debug.Log("------");
        shuffleDeck();
        //printDeck();
    }

    private void Update()
    {
        
    }
    /*borrowed this because there's no collections shuffle method*/
    public void shuffleDeck()
    {

        for (int i = 0; i < deck.Count; i++)
        {
            GameObject temp = deck[i];
            int randomIndex = Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            //deck[randomIndex].GetComponent<CardManager>().cardIndex = i;
           // deck[i].GetComponent<CardManager>().cardIndex = randomIndex;

            deck[randomIndex] = temp;
        }

    }
    public void printDeck()
    {
        foreach (GameObject go in deck)
        {
            Debug.Log(go.name);
        }
    }
}
