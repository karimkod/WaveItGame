using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManagement : MonoBehaviour {


    public Text scoreText;
    public Image healthImage;
    public Text texto;
    public int number;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        scoreText.text = ScoreHandler.Instance.getScore().ToString("F");
        healthImage.fillAmount = ScoreHandler.Instance.getTimeRemaining() / 100;
	}

    public void setText()
    {
        texto.text = number.ToString();
    }
}
