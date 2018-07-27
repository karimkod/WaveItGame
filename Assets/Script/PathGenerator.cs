using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class PathGenerator : MonoBehaviour
{
    public Animator _animator;
    public float min;
    public float range;
    private string toRandomizeParameter;
    private System.Random random;
    public string[] Triggers;
	
    void Start()
    {
        random = new System.Random(); 
    }
    public void ChooseMecanism()
    {

        int index = random.Next(0,Triggers.Length);


        if (Triggers[index] == "Rectangle")
        {
            int boolean = random.Next(0, 2);
            _animator.SetBool(Triggers[index], ((boolean == 0) ? false : true));
        }
        else
        {
            _animator.SetTrigger(Triggers[index]);
        }
    }
}
