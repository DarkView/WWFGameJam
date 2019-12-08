using System;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using  UnityEngine.UI;
using Random = System.Random;

public class MainMenuButtons : MonoBehaviour
{
    private int gamesPlayed;
    [SerializeField] private GameObject spucke;
    [SerializeField] private GameObject ohneSpucke;
    private int background;

    private void Start()
    {
        gamesPlayed = PlayerPrefs.GetInt("GamesPlayedKey", 0);
        background = UnityEngine.Random.Range(1, 100);
        if (background < 90)
        {
            spucke.SetActive(true);
            ohneSpucke.SetActive(false);
        }
        else
        {
            spucke.SetActive(false);
            ohneSpucke.SetActive(true);
        }

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
