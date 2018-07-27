using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ScoreDispalyManager : MonoBehaviour
{
    public Text TypeScoreText;
    public Text TheScoreText;
    public Text TheBestText;
    private float Score;
    private float BestScore;
	// Use this for initialization
	void Start ()
    {
        BestScore = PlayerPrefs.GetFloat("BestScore",0);
        Score = PlayerPrefs.GetFloat("Score"); 

        if (Score > BestScore)
        {
            BestScore = Score;
            PlayerPrefs.SetFloat("BestScore", Score);
            TypeScoreText.text = "New Record"; 
        }else
        {
            TypeScoreText.text = "Score"; 
        }
        TheScoreText.text = Score.ToString("F");
        TheBestText.text = BestScore.ToString("F");
        
	}
	
    public void laod(string sceneName)
    {
        LaodSceneScript.instance.LaodScreen(sceneName);
    }
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            laod("GameMenu");
        }
	}
}
