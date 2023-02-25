using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet3 : Bullet
{
    // Start is called before the first frame update
    void Start()
    {
        speed = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
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

    public override void move() {}

    public override void Fire(List<GameObject> GunPos)
    {
        for(int i = 0; i < 5; i++)
        {
            var rotation = Quaternion.Euler(0f, 0f, 30*(i+1) + 90);
            GameObject bulletClone = Instantiate(gameObject, GunPos[0].transform.position, rotation);
            transform.rotation = rotation;
            bulletClone.GetComponent<Rigidbody2D>().velocity = transform.up * 2.0f;
        }
    }

}
