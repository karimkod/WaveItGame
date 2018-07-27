using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayScript : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "TheCollider")
        {
            
            other.gameObject.SetActive(false);
            ScoreHandler.Instance.incScore();

        }
    }

    
}
