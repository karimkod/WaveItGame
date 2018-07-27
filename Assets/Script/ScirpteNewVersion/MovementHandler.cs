using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{

    #region offsetsTables 
    public Vector3[] offsetTableTriangle;
    public Vector3[] offsetTableRectangle; 
    #endregion

    private MoveForward moveForward;
    private MoveTriangle moveShaply; 
    public Movement currentMovement;
    public float speed;
    public bool input;
	// Use this for initialization
	void Start ()
    {
        input = true;   
        moveForward = new MoveForward(0, 2, 0, this.transform);
        moveShaply = new MoveTriangle(this);
        currentMovement = moveForward; 
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentMovement.Current, speed * Time.deltaTime); 

        if (transform.position == currentMovement.Current)
        {
            currentMovement.NextPoint(); 
        }
       
      
	}

    public void Reset()
    {
        currentMovement = moveForward; 
    }

    public void ApplyTriangle(bool right)
    {
        moveShaply.setOffsetTable(offsetTableTriangle);
        moveShaply.setDirection(right);
        moveShaply.setStartPoint(this.transform.position);
        currentMovement = moveShaply;
    }
    
    public void ApplyRectangle(bool right)
    {
        moveShaply.setOffsetTable(offsetTableRectangle);
        moveShaply.setDirection(right);
        moveShaply.setStartPoint(this.transform.position);
        currentMovement = moveShaply;
    }
}

