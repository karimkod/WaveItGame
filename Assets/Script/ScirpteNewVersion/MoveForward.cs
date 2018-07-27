using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward :Movement
{
    public Vector3 offset;
    public Transform playerTransform; 

    public MoveForward(float x, float y, float z, Transform playerTrans)
    {
        offset = new Vector3(x, y, z);
        playerTransform = playerTrans; 
    }
    public void NextPoint()
    {
        return; 
    }

    public void Reset()
    {
        return; 
    }
    
    public Vector3 Current
    {
        get
        {
            return playerTransform.position + offset; 
        }
        set { } 
    }

}
