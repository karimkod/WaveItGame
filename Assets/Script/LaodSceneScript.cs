using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LaodSceneScript : MonoBehaviour {

    public static LaodSceneScript instance;
    public Animator _animator;
    public string SceneName ;
    private bool hasLaoded; 

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        if (instance == null)
        {
            instance = this; 
        }
        else
        {
            if (instance != this)
                Destroy(gameObject);

        }


    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == SceneName && !hasLaoded)
        {
            hasLaoded = true;
            GoToScreen();
        }
    }
    public void LaodTheScreen()
    {
        hasLaoded = false;
        SceneManager.LoadScene(SceneName);
    }

    public void GoToScreen()
    {
        _animator.SetTrigger("Goto");
    }

    public void LaodScreen(string SceneNameGiven)
    {
        SceneName = SceneNameGiven;
        GoToScreen();
    }
}
