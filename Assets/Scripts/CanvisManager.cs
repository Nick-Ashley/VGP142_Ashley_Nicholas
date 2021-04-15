using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CanvisManager : MonoBehaviour
{
    [Header("Buttons")]
    public Button startButton;
    public Button quitbutton;
    public Button replaybutton;
    public Button BackToMenubutton;
    public Button returnToGamebutton;
    public Button returnToMenubutton;
    public Button Settingsbutton;
    public Button SettingsbuttonPause;
    public Button BackToPausebutton;
    [Header("Text")]
    public Text VolText;
    public Text PauseVolText;
    [Header("Menus")]
    public GameObject PauseMenu;
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject pauseSettingsMenu;

    [Header("Sliders")]
    public Slider Vslider;
    public Slider PauseVslider;
    public int volume;
    public static bool IsGamePaused = false;
    

    public AudioClip pauseSound;
    AudioSource pauseAudio;

    // Start is called before the first frame update
    void Start()
    {

        if (PauseMenu)
        {
            pauseAudio = gameObject.AddComponent<AudioSource>();
            pauseAudio.clip = pauseSound;
            pauseAudio.loop = false;
        }




        if (startButton)
        {
            startButton.onClick.AddListener(() => GameManager.instance.StartGame());


        }
        if (quitbutton)
        {

            quitbutton.onClick.AddListener(() => GameManager.instance.QuitGame());
        }
        if (replaybutton)
        {
            replaybutton.onClick.AddListener(() => GameManager.instance.RestartStartGame());


        }
        if (returnToGamebutton)
        {
            returnToGamebutton.onClick.AddListener(() => Resume());
            if (returnToMenubutton)
            {
//returnToMenubutton.onClick.AddListener(() => GameManager.instance.ReturnToMenu());

            }


        }
        if (BackToMenubutton)
        {
            BackToMenubutton.onClick.AddListener(() => ShowMainMenu());
        }
        if (Settingsbutton)
        {
            Settingsbutton.onClick.AddListener(() => ShowSettingsMenu());
        }
        if (SettingsbuttonPause)
        {
            SettingsbuttonPause.onClick.AddListener(() => ShowSettingsMenuPause());
        }
        if (BackToPausebutton)
        {
            BackToPausebutton.onClick.AddListener(() => ShowPauseMenuPause());
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        

        if (PauseMenu)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {


                if (IsGamePaused)
                {
                    pauseAudio.Play();
                    Resume();

                }
                else
                {
                    pauseAudio.Play();
                    PauseGame();
                }
            }
        }
        if (settingsMenu)
        {
            if (settingsMenu.activeSelf)
            {
                VolText.text = (Vslider.value * 100).ToString();


            }
        }
        if (pauseSettingsMenu)
        {
            if (pauseSettingsMenu.activeSelf)
            {
                PauseVolText.text = (PauseVslider.value * 100).ToString();


            }
        }
    }

    void Resume()
    {
        PauseMenu.SetActive(false);
        IsGamePaused = false;
        Time.timeScale = 1f;
    }
    void PauseGame()
    {
        IsGamePaused = true;
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }


    void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);

    }
    void ShowSettingsMenu()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    void ShowSettingsMenuPause()
    {
        PauseMenu.SetActive(false);
        pauseSettingsMenu.SetActive(true);
    }
    void ShowPauseMenuPause()
    {
        PauseMenu.SetActive(true);
        pauseSettingsMenu.SetActive(false);
    }
    
    
}

