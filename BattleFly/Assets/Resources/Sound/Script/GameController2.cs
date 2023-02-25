using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController2 : MonoBehaviour
{
    public EnemyController2 enemy;
    public GameOver2 gameover;
    public Victory2 victory;
    public Player player;
    public waveconfig waveconfigs;



    // Start is called before the first frame update
    void Start()
    {
        timeDelay = 0;
        timeDelay1 = 0;
        timeDelay2 = 0;
        timer = 0;
        countEnemy = 0;
        countEnemy1 = 0;
        string pathConfig = "config/config1";
        waveconfigs = Resources.Load<waveconfig>(pathConfig);
        this.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.health <= 0)
        {
            gameover.setUp(player.star);
        }
        Round2();
    }

    public bool endgame = false;
    public float timer;
    public float timeDelay, timeDelay1, timeDelay2;
    public int countEnemy, countEnemy1;

    public void Round2()
    {
        if (endgame)
        {
            timeDelay2 += Time.deltaTime;
            if (timeDelay2 >= waveconfigs.configs[2].timeDelay)
            {
                victory.VictorySetUp(player.star);
            }
            return;
        }

        Wave1();
        Wave2();
        Wave3();
    }
//--------------------------------------------------------------------------------------------------------------------------------------//

    public void Wave1()
    {
        if (countEnemy < waveconfigs.configs[0].count)
        {
            timer += Time.deltaTime;
            if (timer >= waveconfigs.configs[0].timer)
            {
                timer = 0;
                enemy.CreateEnemy1(waveconfigs.configs[0].enemyDatas);
                countEnemy++;
            }
        }
        enemy.Move1();
    }



    //------------------------------------------------------------------------------------------------------------------------------------//

    public void Wave2()
    {


        if (countEnemy >= waveconfigs.configs[0].count && enemy.E1Lists.Count < 1  && countEnemy1 < waveconfigs.configs[1].count)
        {
            if (timeDelay < waveconfigs.configs[0].timeDelay) timeDelay += Time.deltaTime;
            else
            {
                timer += Time.deltaTime;
                if (timer >= waveconfigs.configs[1].timer)
                {
                    timer = 0;
                    enemy.CreateEnemy2(waveconfigs.configs[1].enemyDatas);
                    countEnemy1++;
                }
            }
        }
        enemy.Move2();
    }


    public void Wave3()
    {
        if (countEnemy >= waveconfigs.configs[0].count && enemy.E1Lists.Count < 1 && countEnemy1 >= waveconfigs.configs[1].count && enemy.E2Lists.Count < 1)
        {

            if (!enemy.created) timeDelay1 += Time.deltaTime;
            if (timeDelay1 >= waveconfigs.configs[1].timeDelay)
            {
                endgame = enemy.Move3(waveconfigs.configs[2].enemyDatas);
            }
        }
    }




}
