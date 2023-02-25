using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public Text level;
    public void Play()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SoundController.PlaySound(soundsGame.soundButtonClick);
        if(level.text == "Level 1") SceneManager.LoadScene("Level1");

        if (level.text == "Level 2") SceneManager.LoadScene("Level2");

    }
    public void SetLevel()
    {
        SoundController.PlaySound(soundsGame.soundButtonClick);

        if (level.text == "Level 1")
        {
            level.text = "Level 2";
        }
        else if (level.text == "Level 2")
        {
            level.text = "Level 1";
        }
    }

    public void QuitGame()
    {
        SoundController.PlaySound(soundsGame.soundButtonClick);
        Application.Quit();
    }

    public void Setting()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SoundController.PlaySound(soundsGame.soundButtonClick);
    }

}
