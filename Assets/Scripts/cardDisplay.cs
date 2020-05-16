using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cardDisplay : MonoBehaviour
{
    //make this public so that the CardManager script can update the image sprite
    public static Sprite currentSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //repaints the image based on the most recently hovered card
        gameObject.GetComponent<Image>().sprite = currentSprite;
    }

}
