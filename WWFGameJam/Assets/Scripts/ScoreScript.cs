using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public int Score;

    private int Highscore;

    [SerializeField] Text score;

        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
