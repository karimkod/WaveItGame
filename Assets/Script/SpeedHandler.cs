using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedHandler : MonoBehaviour
{
    public Animator blueAnimator;
    public Animator redAnimator;
    private bool level1;
    private bool level2;

    public float speedIncrement;
	// Use this for initialization
	void Start ()
    {
       level1 = level2 = false;
        StartCoroutine(SpeedManager());
	}
	
	// Update is called once per frame
	void Update ()
    {
    }


    IEnumerator SpeedManager()
    {
        while (true)
        {
            if (!level2)
            {
                redAnimator.SetFloat("GameSpeed", redAnimator.GetFloat("GameSpeed") + speedIncrement * Time.deltaTime);
            
            }

            if (redAnimator.GetFloat("GameSpeed") >= 1.5f && !level1)
            {
                level1 = true;
                yield return new WaitUntil(() => (blueAnimator.GetFloat("GameSpeed") != 0)); 
                blueAnimator.SetFloat("GameSpeed", blueAnimator.GetFloat("GameSpeed") + 1f);
            }
            else if (redAnimator.GetFloat("GameSpeed") >= 2.25f && !level2)
            {
                level2 = true;
                yield return new WaitUntil(() => (blueAnimator.GetFloat("GameSpeed") != 0));
                blueAnimator.SetFloat("GameSpeed", blueAnimator.GetFloat("GameSpeed") + 1f);
            }

            yield return null;
        }
        
    }


}
