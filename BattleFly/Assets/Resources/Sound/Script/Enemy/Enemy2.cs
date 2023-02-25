using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemy
{
    // Start is called before the first frame update
    public GameObject bang1;
 //   public GameObject bang2;
    public Bullet1 bullet1;
    public Bullet2 bullet2;
    public Rocket rocket;
    //

    public GameObject item1, item2, item3, item4, item5;
    public List<GameObject> Items = new List<GameObject>();

    void Start()
    {
        heath = 250;
        MaxPoint = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0.0f));
        MinPoint = Camera.main.ScreenToWorldPoint(Vector3.zero);

        Items.Add(item1);
        Items.Add(item2);
        Items.Add(item3);
        Items.Add(item4);
        Items.Add(item5);
    }

    // Update is called once per frame
    void Update()
    {
        Remove();
    }

    float timer = 0.25f;
    public void OnTriggerStay2D(Collider2D collision)
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
            timer += Time.deltaTime;
            if(timer >= 0.25f)
            {
                timer = 0;
                this.heath -= bullet2.dame;//////////////////////////////////////
                Instantiate(bang1, transform.position, Quaternion.identity);
                SoundController.PlaySound(soundsGame.soundExplode1);
            }
        }

        if (collision.CompareTag("rocket"))
        {
            Destroy(collision.gameObject);
            this.heath -= rocket.dame;
        }
    }
    public override void Remove()
    {

        if (transform.position.x - 1.0f > MaxPoint.x || transform.position.x + 1.0f < MinPoint.x || transform.position.y - 1.0f > MaxPoint.y || transform.position.y + 1.0f < MinPoint.y)
        {
            Destroy(gameObject);
        }
        if (heath <= 0)
        {
            int index = Random.Range(0, 6);
            if (index >= 0 && index <= 4) Instantiate(Items[index].gameObject, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
