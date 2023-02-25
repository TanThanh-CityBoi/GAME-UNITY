using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Victory : MonoBehaviour
{
    public Text StarText;
    public GameController gameCol;

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

    //
    public void VictorySetUp(int star)
    {
        gameCol.GetComponent<AudioSource>().Stop();
        gameObject.SetActive(true);
        StarText.text = star.ToString() + " Star";
    }
    public void MainMenu()
    {
        SoundController.PlaySound(soundsGame.soundButtonClick);
        flag2 = true;
    }

    public void NextLevel()
    {
        SoundController.PlaySound(soundsGame.soundButtonClick);
        flag1 = true;
    }
}
