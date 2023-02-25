using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : Bullet
{
    public int bulletNum;

    // Start is called before the first frame update
    void Start()
    {
        //dame = 25;
        bulletNum = 1;
    }

    // Update is called once per frame
    void Update()
    {
        move();
        RemoveBullet();
    }

    public override void RemoveBullet()
    {
        MaxPoint = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0.0f));
        MinPoint = Camera.main.ScreenToWorldPoint(Vector3.zero);

        if (transform.position.x > MaxPoint.x || transform.position.x < MinPoint.x || transform.position.y > MaxPoint.y || transform.position.y < MinPoint.y)
        {
            Destroy(gameObject);
        }
    }

    public override void move()
    {
        if(bulletNum <= 3)
        {
            this.transform.position += new Vector3(0.0f, speed * Time.deltaTime, 0.0f);
        }
        switch (bulletNum)
        {
            case 1:
            case 2:
                {
                    this.transform.position += new Vector3(0.0f, speed * Time.deltaTime, 0.0f);
                    break;
                }
        }
    }

    public override void Fire(List<GameObject> GunPos)
    {
        SoundController.PlaySound(soundsGame.soundGunShoot);
        switch (bulletNum) 
        {
            case 1:
                {
                    Instantiate(gameObject, GunPos[0].transform.position, Quaternion.identity);
                    break;
                }
            case 2:
                {
                    Instantiate(gameObject, GunPos[1].transform.position, Quaternion.identity);
                    Instantiate(gameObject, GunPos[2].transform.position, Quaternion.identity);
                    break;
                }
            case 3:
                {
                    fire1(0, GunPos);
                    fire1(1, GunPos);
                    fire1(2, GunPos);
                    break;
                }
            case 4:
                {
                    fire1(1, GunPos);
                    fire1(2, GunPos);
                    fire1(3, GunPos);
                    fire1(4, GunPos);
                    break;
                }
            case 5:
                {
                    fire1(0, GunPos);
                    fire1(1, GunPos);
                    fire1(2, GunPos);
                    fire1(3, GunPos);
                    fire1(4, GunPos);
                    break;
                }
            default: break;

        }

    }

    public void fire1(int index, List<GameObject> GunPos)
    {
        Vector3 LookDirection = GunPos[index].transform.position - GunPos[5].transform.position;
        LookDirection.Normalize();
        float look = Mathf.Atan2(LookDirection.y, LookDirection.x) * Mathf.Rad2Deg;
        var rotation = Quaternion.Euler(0f, 0f, look - 90.0f);
        GameObject bulletClone = Instantiate(gameObject, GunPos[index].transform.position, rotation);
        bulletClone.GetComponent<Rigidbody2D>().velocity = LookDirection * speed;
    }
}
