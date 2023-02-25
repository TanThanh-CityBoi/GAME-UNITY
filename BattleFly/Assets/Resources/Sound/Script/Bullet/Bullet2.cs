using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : Bullet
{
    // Start is called before the first frame update
    public GameObject gunPos;
    public bool enable;
    
    void Start()
    {
     //   dame = 100;
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
        if (Input.GetKeyUp(KeyCode.S))
        {
            Destroy(gameObject);
        }
    }
    public override void move()
    {
        transform.position = gunPos.transform.position;
    }


    public override void Fire(List<GameObject> GunPos)
    {
        if (!enable) return;
        gunPos = GunPos[0];
        var rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
        Instantiate(gameObject, GunPos[0].transform.position, rotation);
        SoundController.PlaySound(soundsGame.soundLaserShoot);
    }
}
