using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Bullet
{
    public GameObject explode2;
    public GameObject ExPos;
    public GameObject target;
    public int rocketNum;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5.0f;
        //dame = 200;
        target = GameObject.FindGameObjectWithTag("enemy");
    }

    // Update is called once per frame
    void Update()
    {
        RemoveBullet();
        move();
    }
    ///------------------------------------------------------------------------------------------------------------------///
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
        if (target != null)
        {
            Quaternion targetRotation = Quaternion.Euler(0.0f, 0.0f, GetRotation());
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation , targetRotation, 5.0f * Time.deltaTime);
        }
        this.transform.position += transform.up * speed * Time.deltaTime;
    }

    public float GetRotation()
    {
        Vector3 direction = target.transform.position - transform.position;
        direction.Normalize();
        float result = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        return result;
    }
    ///-----------------------------------------------------------------------------------------------------------------///
    public override void Fire(List<GameObject> GunPos)
    {
        if (rocketNum == 0) return;
        Instantiate(gameObject, GunPos[0].transform.position, Quaternion.identity);
        SoundController.PlaySound(soundsGame.soundRocket);
        rocketNum--;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            Instantiate(explode2, ExPos.transform.position, Quaternion.identity);
            SoundController.PlaySound(soundsGame.soundExplode);
        }
    }
}
