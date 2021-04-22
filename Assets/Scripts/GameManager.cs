using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using System;



public class GameManager : MonoBehaviour
{


    static GameManager _instance = null;
    public static GameManager instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

    // Start is called before the first frame update
    void Start()
    {

        if (instance)
        {
            Destroy(gameObject);

        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }


    }

    public GameObject playerPrefab;
    //public LevelManager currentLevel;

    // Update is called once per frame
    void Update()
    {
        try
        {

            if (Input.GetKeyDown(KeyCode.Escape))

            {
                if (SceneManager.GetActiveScene().name == "MainLevel")
                {
                    SceneManager.LoadScene("TitleScreen");

                }
                else if (SceneManager.GetActiveScene().name == "TitleScreen")
                {

                    SceneManager.LoadScene("MainLevel");

                }
                else if (SceneManager.GetActiveScene().name == "GameOver")
                {
                    SceneManager.LoadScene("TitleScreen");
                }

            }
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                QuitGame();
            }
        }
        catch (NullReferenceException e)
        {
            Debug.LogWarning(e.Message);
        }
    }




        public void StartGame()
        {

            SceneManager.LoadScene("MainLevel");

        }
        public void RestartStartGame()
        {

        SceneManager.LoadScene("TitleScreen");

        }

        public void QuitGame()
        {

#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif

        }
    
}