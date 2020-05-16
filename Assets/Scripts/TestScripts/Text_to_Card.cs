using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Run this on a text field. The contents of the textfield will be what kind of card spawns when you press Enter*/
public class Text_to_Card : MonoBehaviour
{
    public string text;
    public float xPos = 550;
    public float yPos = -500;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text = gameObject.GetComponent<Text>().text;
       // Debug.Log(text);

        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameObject testCard = (GameObject)Instantiate(Resources.Load("Cards/"+text));
            testCard.transform.position = new Vector3(xPos, yPos,0);
            xPos+= testCard.GetComponent<SpriteRenderer>().sprite.bounds.size.x + 10;
        }
    }

    
    public string getText()
    {
        //gameObject.GetComponent<Text>().text;
        return "";
    }
}
