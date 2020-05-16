using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCard : MonoBehaviour
{
    CardManager cardManager;
    int cardIndex = 105;

    public GameObject card;
    // Start is called before the first frame update

    private void Awake()
    {
        cardManager = card.GetComponent<CardManager>();
    }

    private void OnGUI()
    {
        if(GUI.Button(new Rect(10, 10, 100, 28),"Click!!")){
            
            if (cardIndex >= cardManager.cardFronts.Count)
            {
                cardIndex = 0;
                cardManager.flipCard(false);
            }
            else 
            {
                cardManager.cardIndex = cardIndex;
                cardManager.flipCard(true);
                cardIndex++;

            }

        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
