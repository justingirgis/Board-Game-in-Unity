using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateCard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        genCard();
        
    }

    private void genCard()
    {
        GameObject myCard = (GameObject)Instantiate(Resources.Load("sample_card"));
        GameObject card = (GameObject)Instantiate(myCard, transform);
        Destroy(myCard);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
