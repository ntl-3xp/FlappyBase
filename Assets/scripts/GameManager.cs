using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject startCanvas;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        //Time.timeScale = 1f;
    }

    public void Start()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
        AudioListener.volume = 0;
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;


    }

    public void Update()
    {
        if (YandexGame.nowFullAd == false)
        {
            if (startCanvas.activeSelf && Keyboard.current.spaceKey.wasPressedThisFrame)
                StartGame();
        }
        else
        {
            Time.timeScale = 0f;
            AudioListener.pause = true;
            AudioListener.volume = 0;
        }
            
    }

    public void Restart()
    {
                //вывод окна рекламы
        YandexGame.FullscreenShow();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        startCanvas.SetActive(false);
        AudioListener.volume = 1;

    }
}
