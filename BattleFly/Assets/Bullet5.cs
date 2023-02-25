using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet5 : Bullet
{
    public float timer;
    void Start()
    {
        //   dame = 100;
        timer = 0;
        MaxPoint = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0.0f));
    }

    // Update is called once per frame
    void Update()
    {
        move();
        RemoveBullet();
    }

    public override void RemoveBullet()
    {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            timer = 0;
            Destroy(gameObject);
        }
    }
    public override void move()
    {
    }


    public override void Fire(List<GameObject> GunPos)
    {
        int i = Random.Range(0, GunPos.Count - 1);
        //var rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        Instantiate(gameObject, GunPos[i].transform.position, Quaternion.identity);
        SoundController.PlaySound(soundsGame.soundLaserShoot);
    }
}
