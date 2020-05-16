using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    // Start is called before the first frame update
    //this attaches to every card
    SpriteRenderer spriteRenderer;
    Sprite currentSprite;
    int cardOwner = 1;

    [SerializeField]
    public Sprite cardBack;
    [SerializeField]
    public List<Sprite> cardFronts;
    //[SerializeField]
    GameObject mbSprite;

    public int cardIndex;
    public int[] arrows = { (int)CardArrow.NONE, (int)CardArrow.NONE, (int)CardArrow.NONE, (int)CardArrow.NONE };
    public int[] stats = { 0, 0, 0, 0 };

    public int treasuryAmount = 0;
    public GameObject treasuryText;
    GameObject myCanvas; 
    Text treasuryPrefabText;

    void Start()
    {
        treasuryAmount = 0;
        //this makes the the class's SpriteRenderer into the one that the script is attached to
        spriteRenderer = GetComponent<SpriteRenderer>();
        //we access the sprite of the object that the script is attached to
        currentSprite = spriteRenderer.sprite;
        instantiateTreasury();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver()
    {
        //assign the sprite to the cardDisplay script's currentSprite, so that it can update the image
        if (cardDisplay.currentSprite != currentSprite)
        {
            cardDisplay.currentSprite = currentSprite;
        }
    }

    public void updateTreasury()
    {
        treasuryAmount += stats[(int)CardStatEnums.Income];

        treasuryPrefabText.text = treasuryAmount.ToString();
    }
    public void instantiateTreasury()
    {
        myCanvas= GameObject.Find("Canvas2");
        treasuryText = new GameObject("someText");
        treasuryText.transform.SetParent(myCanvas.transform);

        treasuryPrefabText = treasuryText.AddComponent<Text>();
        //Debug.Log("Treasury amount: " + treasuryAmount.ToString());
        treasuryPrefabText.text = treasuryAmount.ToString();
        Font Arial =(Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        treasuryPrefabText.font = Arial;
        treasuryPrefabText.transform.localScale = new Vector3((float)0.1, (float)0.1, (float)0.1);
        treasuryPrefabText.fontSize = 32;
        treasuryPrefabText.color = Color.black;//(Color)Resources.GetBuiltinResource(typeof(Color), "Black.ttf");
        treasuryPrefabText.material = Arial.material;
        treasuryPrefabText.transform.position = new Vector3(gameObject.transform.position.x + (float)9.24, gameObject.transform.position.y + (float)5, -2);


         mbSprite= (GameObject)Instantiate(Resources.Load("Money/0MB"));
        mbSprite.transform.position = new Vector3(gameObject.transform.position.x + (float)5.75, gameObject.transform.position.y + (float)8.5, -1);
        //treasuryPrefabText= Instantiate()
    }
    public void flipCard(bool front)
    {
        if (front)
        {
            spriteRenderer.sprite = cardFronts[cardIndex];
        }
        else
        {
            spriteRenderer.sprite = cardBack;
        }
    }

    public void assignStats()
    {
        for(int i = 0; i < arrows.Length; i++)
        {
            arrows[i] = GameManager.Instance.arrows[i];
        }
        for (int i = 0; i < stats.Length; i++)
        {
            stats[i] = GameManager.Instance.stats[i];
        }
        //gives an update of the card's new arrows after rotating
        /*
        Debug.Log("CardManager now has the following information----");
        foreach(int i in arrows)
        {
            Debug.Log(i);
        }
        */
    }
    

}
