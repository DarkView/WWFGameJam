using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadSceneAsync("GameScene");
    }
}
