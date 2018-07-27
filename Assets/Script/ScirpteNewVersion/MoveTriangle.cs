using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTriangle : Movement
{
    private Vector3[] offsets;
    private Vector3 startPosition;
    public MovementHandler movementHandlerReference; 
    private int right; 
    int index; 
    
    public MoveTriangle(MovementHandler movementHandlerReference)
    {
        this.movementHandlerReference = movementHandlerReference; 
        
    }

    public void NextPoint()
    {

        if (index + 1 >= offsets.Length)
            Reset();
        else
            index++; 
    }

    public void Reset()
    {
        movementHandlerReference.Reset();
        index = 0;
        movementHandlerReference.input = true;
    }

    public Vector3 Current
    {
        get
        {
            return startPosition + new Vector3(right * offsets[index].x, offsets[index].y, offsets[index].z); 
        }
        set { }
    }
    
    public void setDirection(bool right)
    {
        this.right = (right) ? 1 : -1;
    }

    public void setStartPoint(Vector3 startPos)
    {
        this.startPosition = startPos;
        movementHandlerReference.input = false;

    }

    public void setOffsetTable(Vector3[] offsets)
    {
        this.offsets = offsets;
    }


}
