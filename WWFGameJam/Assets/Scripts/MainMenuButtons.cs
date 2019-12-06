using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
<<<<<<< Updated upstream
    public void PlayButton()
    {
        SceneManager.LoadScene("GameScene");
=======
    [SerializeField] private Scene gameField;

    public void PlayButton()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
>>>>>>> Stashed changes
    }
}
