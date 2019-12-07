using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private int Score;

    private int Highscore;

    [SerializeField]
    private Text score;

    private void Start()
    {
        Highscore = PlayerPrefs.GetInt("HighScoreKey", 0);
    }

    // Update is called once per frame
    public void EnemyHit(int addedScore)
    {
        this.Score += addedScore;
        score.text = Score.ToString();
        if (Score > Highscore)
        {
            Highscore = Score;
            PlayerPrefs.SetInt("HighScoreKey", Highscore);
        }

        if (Score > 0 && Score % 100 == 0)
        {
            GameObject.Find("Spawner").GetComponent<EnemySpawner>().delay -= 0.5f;
        }
    }
}
