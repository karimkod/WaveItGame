using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    public Animator _redAnimator;
    public Animator _blueAnimator;
    public Animator _buttonAnimator;
    public Animator _indicatorAnimator;

    private Camera mainCamera;
    public bool inversed = false;
    public RectTransform ToggleSignalButton;

    public SpeedHandler speedHandler; 

    private float redSpeedPause;
    private float blueSpeedPause;
    private bool paused;
    public GameObject pauseMenu;
    public RectTransform pauseButton; 

    // Use this for initialization
    void Start()
    {
        paused = false;
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            Vector2 mousePos = Input.mousePosition;
            if (isHitting(ToggleSignalButton, mousePos) || paused || isHitting(pauseButton, mousePos))
                return;
            if ((mousePos.x > mainCamera.pixelWidth / 2 && !inversed) || (mousePos.x < mainCamera.pixelWidth / 2 && inversed))
            {
                _redAnimator.ResetTrigger("TriggerLeft");
                _indicatorAnimator.SetBool("LeftIndicator", false);
                _indicatorAnimator.SetBool("RightIndicator", true);
                _redAnimator.SetTrigger("TriggerRight");

            }
            else if ((mousePos.x < mainCamera.pixelWidth / 2 && !inversed) || (mousePos.x > mainCamera.pixelWidth / 2 && inversed))
            {

                _redAnimator.ResetTrigger("TriggerRight");
                _indicatorAnimator.SetBool("RightIndicator", false);
                _indicatorAnimator.SetBool("LeftIndicator", true);
                _redAnimator.SetTrigger("TriggerLeft");

            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _redAnimator.SetTrigger("TriggerLeft");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _redAnimator.SetTrigger("TriggerRight");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _redAnimator.SetBool("Rectangle", !_redAnimator.GetBool("Rectangle"));
            _buttonAnimator.SetTrigger("Toggle");

        }
    }


    public void ToggleSignal()
    {
        _redAnimator.SetBool("Rectangle", !_redAnimator.GetBool("Rectangle"));
        _buttonAnimator.SetTrigger("Toggle");
    }

    private bool isHitting(RectTransform UIObject, Vector2 mousePosition)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(UIObject, mousePosition, mainCamera);
    }

    public void pause()
    {
        paused = !paused;
        Time.timeScale = (Time.timeScale == 0) ? 1 : 0;
        ToggleMenu();

    }

    public void ToggleMenu()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }

    public void GoMenu()
    {
        LaodSceneScript.instance.LaodScreen("GameMenu");
        Time.timeScale = 1;

    }

    public void SwitchOffIndicator(string leftOrRight)
    {
        _indicatorAnimator.SetBool(leftOrRight + "Indicator", false);
        return;
    }

}