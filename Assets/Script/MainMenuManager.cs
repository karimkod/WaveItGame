using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    private float Score;
    public Text BestScoreText;
    public Animator _animator;
    public GameObject InfoMen; 
	// Use this for initialization
	void Start ()
    {
		if (!PlayerPrefs.HasKey("BestScore"))
        {
            Score = 0f;
            PlayerPrefs.SetFloat("BestScore", 0f);
        }else
        {
            Score = PlayerPrefs.GetFloat("BestScore");
        }

        BestScoreText.text = Score.ToString("F");

	}
	
    public void ToggleMenu()
    {
        InfoMen.SetActive(!InfoMen.activeSelf);
    }

    public void GoFacebook()
    {
        Application.OpenURL("https://www.facebook.com/PptStd/");    
    }
    // Update is called once per frame
    
    public void playScene(string nameScene)
    {
        LaodSceneScript.instance.LaodScreen(nameScene);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
