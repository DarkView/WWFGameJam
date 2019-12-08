using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreMenuScript : MonoBehaviour
{
    [SerializeField] private Text highscore;
    [SerializeField] private Text gamesPlayed;
    [SerializeField] private Text abilitiesUsed;
    [SerializeField] private Text killWithoutStick;
    [SerializeField] private Text killWithStick;


    // Start is called before the first frame update
    void Start()
    {
        highscore.text = PlayerPrefs.GetInt("HighScoreKey", 0).ToString();
        gamesPlayed.text = PlayerPrefs.GetInt("GamesPlayedKey", 0).ToString();
        abilitiesUsed.text = PlayerPrefs.GetInt("AbilitiesUsedKey", 0).ToString();
        killWithoutStick.text = PlayerPrefs.GetInt("KillWithoutStickKey", 0).ToString();
        killWithStick.text = PlayerPrefs.GetInt("KillWithStickKey", 0).ToString();
    }
}
