<<<<<<< Updated upstream
﻿
=======
﻿using System.Collections;
using System.Collections.Generic;
>>>>>>> Stashed changes
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
