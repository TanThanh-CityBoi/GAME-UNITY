using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5 : Enemy
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

    }

    // Update is called once per frame
    void Update()
    {
        Remove();
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
}
