using System;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using  UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    private int gamesPlayed;

    private void Start()
    {
        gamesPlayed = PlayerPrefs.GetInt("GamesPlayedKey", 0);
    }

    public void PlayButton()
    {
        SceneManager.LoadSceneAsync("GameScene");
        PlayerPrefs.SetInt("GamesPlayedKey",gamesPlayed++);
    }

    public void HighscoreButton()
    {
        SceneManager.LoadSceneAsync("HighScoreScene");
    }
}
