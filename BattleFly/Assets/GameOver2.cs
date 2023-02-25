using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver2 : MonoBehaviour
{
    public Text starText;
    public GameController2 gameCol;
    public float timer1, timer2;
    bool flag1, flag2;



    public void Start()
    {
        timer1 = 0;
        timer2 = 0;
        flag1 = false;
        flag2 = false;
    }
    public void Update()
    {
        if (flag1) timer1 += Time.deltaTime;
        if (flag2) timer2 += Time.deltaTime;
        if (timer1 >= 0.5)
        {
            SceneManager.LoadScene("Level2");
        }
        if (timer2 >= 0.5)
        {
            SceneManager.LoadScene("Mainmenu");
        }
    }
    public void setUp(int star)
    {
        gameCol.GetComponent<AudioSource>().Stop();

        gameObject.SetActive(true);
        starText.text = star.ToString() + " Star";
    }


    public void RestartButton()
    {
        SoundController.PlaySound(soundsGame.soundButtonClick);
        flag1 = true;
    }

    public void QuitButton()
    {
        SoundController.PlaySound(soundsGame.soundButtonClick);
        flag2 = true;
    }
}
