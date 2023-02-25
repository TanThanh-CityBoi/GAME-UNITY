using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : Enemy
{

    public GameObject bang1;
    public GameObject explode2;
    public Bullet1 bullet1;
    public Bullet2 bullet2;
    public Bullet3 bullet3;
    public Rocket rocket;
    //
    public GameObject gunPos1;
    public List<GameObject> GunPos = new List<GameObject>();
    public float timer;
    //
    public GameObject luckyBox;

    // Start is called before the first frame update
    void Start()
    {
        heath = 5000;
        MaxPoint = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0.0f));
        MinPoint = Camera.main.ScreenToWorldPoint(Vector3.zero);

        GunPos.Add(gunPos1);
        timer = -3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Remove();
        Shooting();
    }

    public float timer2 = 0.25f;
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
            timer2 += Time.deltaTime;
            if (timer2 >= 0.25f)
            {
                timer2 = 0;
                this.heath -= bullet2.dame;//////////////////////////////////////
                Vector3 pos = new Vector3(collision.gameObject.transform.position.x, transform.position.y - transform.localScale.y, 0);
                Instantiate(bang1, pos, Quaternion.identity);
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

        if (heath <= 0)
        {
            Destroy(gameObject);
            Vector3 pos = new Vector3(transform.position.x - transform.localScale.x, transform.position.y - transform.localScale.y, 0);
            Instantiate(explode2, pos, Quaternion.identity);
            SoundController.PlaySound(soundsGame.soundExplode);

            Instantiate(luckyBox, pos, Quaternion.identity);
        }
    }

    public void Shooting()
    {
        timer += Time.deltaTime;
        if(timer >= 0.8)
        {
            timer = 0;
            bullet3.Fire(GunPos);
        }
    }
}
