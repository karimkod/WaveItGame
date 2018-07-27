using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    private static ScoreHandler instance; 
    public static ScoreHandler Instance { get { return instance; } }

    public Animator _redAnimator;
    public Animator _blueAnimator;
    public Animator _endAnimator; 

    private float Score;
    private float timeRemaining = 100; 

	// Use this for initialization
	void Start ()
    {
		if (instance == null)
        {
            instance = this;
        }else
        {
            if (instance != this)
                Destroy(gameObject);
        }

	}

    void Update()
    {

    }

    public void incScore()
    {
        Score = Score + 0.01f; 
    }

    public void decTimeRemaining()
    {
        timeRemaining = timeRemaining - 2;
        if (timeRemaining <= 0)
        {
            StartCoroutine(LooseProcedure());
        }
    }

    public float getScore()
    {
        return Score; 
    }

    public float getTimeRemaining()
    {
        return timeRemaining;

    }

    public IEnumerator LooseProcedure()
    {
        _redAnimator.SetFloat("GameSpeed", 0.0f);
        _blueAnimator.SetFloat("GameSpeed", 0.0f);
        saveScore();
        LaodSceneScript.instance.SceneName = "TheScoreScene";
        _endAnimator.SetTrigger("End");

        yield return new WaitForSeconds(3.2f);
        LaodSceneScript.instance.GoToScreen();
    }

    public void saveScore()
    {
        PlayerPrefs.SetFloat("Score", Score);
    }
}
