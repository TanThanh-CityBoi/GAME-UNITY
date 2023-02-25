using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy6 : Enemy
{
    // Start is called before the first frame update
    public GameObject bang1;
    //  public GameObject bang2;
    public Bullet1 bullet1;
    public Bullet2 bullet2;
    public Rocket rocket;
    //

    public GameObject item1, item2, item3, item4, item5, item6;
    public List<GameObject> Items = new List<GameObject>();

    //
    public GameObject bullet3;

    void Start()
    {
        heath = 200;
        MaxPoint = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0.0f));
        MinPoint = Camera.main.ScreenToWorldPoint(Vector3.zero);

        Items.Add(item1);
        Items.Add(item2);
        Items.Add(item3);
        Items.Add(item4);
        Items.Add(item5);
        Items.Add(item6);

        shootDelay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Remove();
        Fire();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet1"))
        {
            Destroy(collision.gameObject);
            this.heath -= bullet1.dame;
            Instantiate(bang1, collision.gameObject.transform.position, Quaternion.identity);
            SoundController.PlaySound(soundsGame.soundExplode1);

        }

        if (collision.CompareTag("bullet2"))
        {
            this.heath -= bullet2.dame;
            Instantiate(bang1, transform.position, Quaternion.identity);
            SoundController.PlaySound(soundsGame.soundExplode1);

        }

        if (collision.CompareTag("rocket"))
        {
            Destroy(collision.gameObject);
            this.heath -= rocket.dame;
        }
    }
    public override void Remove()
    {
        if (heath <= 0)
        {
            int index = Random.Range(0, 7);
            if (index >= 0 && index <= 5) Instantiate(Items[index].gameObject, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


    public float shootDelay;
    public void Fire()
    {
        shootDelay += Time.deltaTime;

        if(shootDelay >= 1)
        {
            shootDelay = 0;
            GameObject bullet3clone = Instantiate(bullet3, transform.position, Quaternion.identity);
            bullet3clone.GetComponent<Rigidbody2D>().velocity = new Vector3(0.0f, -1.0f, 0.0f) * 4.0f;
        }
    }
}
