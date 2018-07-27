using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform toFollow;
    public Vector3 offset;

    private Camera mainCamera;
    private Vector3 refVelocity;
    private Vector3 toCalcul;
    public bool followOnX;
    public bool followOnY;
    public bool followOnZ;

	// Use this for initialization
	void Start ()
    {
        mainCamera = Camera.main;
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        toCalcul = toFollow.position + offset;
        mainCamera.transform.position = new Vector3(toCalcul.x * ReturnInt(followOnX), toCalcul.y * ReturnInt(followOnY),
            toCalcul.z * ReturnInt(followOnZ));
	}


    int ReturnInt(bool condition)
    {
        return (condition) ? 1 : 0; 
    }
}
