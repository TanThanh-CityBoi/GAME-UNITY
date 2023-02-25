using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Bullet1 bullet1;
    public Bullet2 bullet2;
    public Rocket rocket;
    public float shootDelay;
    public float timer;
    public GameObject gunPos1, gunPos2, gunPos3, gunPos4, gunPos5, gunPos6;
    public List<GameObject> GunPos = new List<GameObject>();
    //
    // Start is called before the first frame update
    void Start()
    {
        shootDelay = 0.15f;
        timer = shootDelay;
 

        bullet1.bulletNum = 1;
        bullet2.enable = false;
        rocket.rocketNum = 0;

        bullet1.dame = 25;
        bullet2.dame = 50;
        rocket.dame = 300;


        GunPos.Add(gunPos1);
        GunPos.Add(gunPos2);
        GunPos.Add(gunPos3);
        GunPos.Add(gunPos4);
        GunPos.Add(gunPos5);
        GunPos.Add(gunPos6);

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.A) && timer >= shootDelay)
        {
            timer = 0;
            bullet1.Fire(GunPos);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            bullet2.Fire(GunPos);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            rocket.Fire(GunPos);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Itembullet1"))
        {
           if(bullet1.bulletNum < 5) bullet1.bulletNum++;
            Destroy(collision.gameObject);
            SoundController.PlaySound(soundsGame.soundItem);
        }

        if (collision.CompareTag("Itembullet2"))
        {
            bullet2.enable = true;
            Destroy(collision.gameObject);
            SoundController.PlaySound(soundsGame.soundItem);

        }

        if (collision.CompareTag("Itemrocket"))
        {
            rocket.rocketNum++;
            Destroy(collision.gameObject);
            SoundController.PlaySound(soundsGame.soundItem);

        }
    }
}
