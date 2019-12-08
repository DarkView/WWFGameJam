using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DefeatScreenScript : MonoBehaviour
{
    private int gamesPlayed;

    [SerializeField]
    private TMP_Text score;

    // Start is called before the first frame update
    void Start()
    {
        gamesPlayed = PlayerPrefs.GetInt("GamesPlayedKey", 0);
        score.text = PlayerPrefs.GetInt("ScoreKey", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync("GameScene");
        PlayerPrefs.SetInt("GamesPlayedKey", gamesPlayed++);
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void HighScoreScene()
    {
        SceneManager.LoadSceneAsync("HighScoreScene");
    }
}
