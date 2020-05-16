using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPosition
{
    // Start is called before the first frame update
    public int xPosition { get; set; }
    public int yPosition { get; set; }
    
    public GridPosition(int xPos, int yPos)
    {
        xPosition = xPos;
        yPosition = yPos;
    }

}
