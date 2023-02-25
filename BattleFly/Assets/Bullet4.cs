using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet4 : Bullet
{
    // Start is called before the first frame update
    void Start()
    {
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

    public override void move() { }

    public override void Fire(List<GameObject> GunPos)
    {
        for (int i = 0; i < GunPos.Count - 1; i++)
        {
            Vector3 direc = GunPos[i].transform.position - GunPos[GunPos.Count - 1].transform.position;
            direc.Normalize();

            var rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Atan2(direc.y, direc.x) * Mathf.Rad2Deg - 90);
            GameObject bulletClone = Instantiate(gameObject, GunPos[i].transform.position, rotation);
            transform.rotation = rotation;
            bulletClone.GetComponent<Rigidbody2D>().velocity = direc * speed;
        }
    }

}
