using System;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using  UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private Text highscore;

    public void PlayButton()
    {
        SceneManager.LoadSceneAsync("GameScene");
    }

    private void Start()
    {
        highscore.text = PlayerPrefs.GetInt("HighScoreKey", 0).ToString();
    }
}
