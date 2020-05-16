using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverCard : MonoBehaviour
{
    // Start is called before the first frame update
    //SpriteRenderer spriteRenderer = GameObject.
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        followMouse();
        if (GameManager.Instance.deck.Count != 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = GameManager.Instance.deck[GameManager.Instance.deckIndex].GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = null;
        }
    }
    private void followMouse()
    {
       // if()
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        transform.rotation = Quaternion.Euler(Vector3.forward * -90 * (GameManager.Instance.rotations % 4));
    }
}
