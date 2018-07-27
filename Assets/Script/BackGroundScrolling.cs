using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScrolling : MonoBehaviour
{
    public float speed;
    public Vector2 wantedPosition;
    public Vector2 beginPosition;
    
	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update()
    {
        transform.localPosition = Vector2.MoveTowards(transform.localPosition, wantedPosition, speed * Time.deltaTime);
        
        if ((Vector2)transform.localPosition == wantedPosition)
        {
            transform.localPosition = beginPosition;
        }
	}
}
