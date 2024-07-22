using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using YG;



public class Score : MonoBehaviour
{
    public static Score instance;
    [SerializeField] private TextMeshProUGUI currentScoretxt;
    [SerializeField] private TextMeshProUGUI highScoretxt;
    private int score;
    public int HighScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        if (YandexGame.SDKEnabled == true)
            LoadSaveCloud();
        currentScoretxt.text = score.ToString();
        highScoretxt.text = HighScore.ToString();
    }

    private void UpdateHighScore()
    {

        if (score > HighScore)
        {
            //PlayerPrefs.SetInt("HighScore", score);
            YandexGame.savesData.highScore = score;
            Debug.Log(YandexGame.savesData.highScore);
            SaveHighScore();
            highScoretxt.text = YandexGame.savesData.highScore.ToString();
            Debug.Log(YandexGame.savesData.highScore);
        }
    }

    public void UpdateScore()
    {
        score++;
        currentScoretxt.text = score.ToString();
        UpdateHighScore();

    }

    public void SaveHighScore()
    {
        //YandexGame.savesData.highScore = HighScore;
        YandexGame.SaveProgress();
        
    }

    public void LoadSaveCloud()
    {
        HighScore = YandexGame.savesData.highScore;
        NewLeaderBord();
    }

    private void OnEnable() 
    {
        YandexGame.GetDataEvent += LoadSaveCloud;
    }

    private void OnDisable() 
    {
        YandexGame.GetDataEvent -= LoadSaveCloud;
    }

    public void NewLeaderBord()
    {
        YandexGame.NewLeaderboardScores("LeaderCat", YandexGame.savesData.highScore);
    }
}
