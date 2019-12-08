using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScoreMenuScript : MonoBehaviour
{
    [SerializeField] private TMP_Text highscore;
    [SerializeField] private TMP_Text gamesPlayed;
    [SerializeField] private TMP_Text abilitiesUsed;
    [SerializeField] private TMP_Text killWithoutStick;
    [SerializeField] private TMP_Text killWithStick;
    
    // Start is called before the first frame update
    void Start()
    {
        highscore.text = PlayerPrefs.GetInt("HighScoreKey", 0).ToString();
        gamesPlayed.text = PlayerPrefs.GetInt("GamesPlayedKey", 0).ToString();
        abilitiesUsed.text = PlayerPrefs.GetInt("AbilitiesUsedKey", 0).ToString();
        killWithoutStick.text = PlayerPrefs.GetInt("KillWithoutStickKey", 0).ToString();
        killWithStick.text = PlayerPrefs.GetInt("KillWithStickKey", 0).ToString();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("HighScoreKey",0);
        PlayerPrefs.SetInt("GamesPlayedKey",0);
        PlayerPrefs.SetInt("AbilitiesUsedKey",0);
        PlayerPrefs.SetInt("KillWithoutStickKey",0);
        PlayerPrefs.SetInt("KillWithStickKey",0);

    }
}
