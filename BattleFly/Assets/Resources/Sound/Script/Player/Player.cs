using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public int star;
    public HealthBar healthBar;////////////////////////////
    //
    public Vector3 MaxPoint;
    public Vector3 MinPoint;
    public Vector3 moursePos;
    public Vector3 mouPlayer;
    public bool flag = false;
    //
    public GameObject explode1;

    //
    public GameObject shield;
    public GameObject shieldClone;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 1000;
        health = maxHealth;
        star = 0;
        healthBar.SetMaxHealth(health);/////////////////////////
        MaxPoint = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0.0f));
        MinPoint = Camera.main.ScreenToWorldPoint(Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth(health);////////////////////////////////
        if(health <= 0)
        {
            this.gameObject.SetActive(false);
        }
        move();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("enemy") || collision.CompareTag("bullet3") || collision.CompareTag("bullet4") || collision.CompareTag("bullet5")) && shieldClone == null)
        {
            this.health -= 200;
            Vector3 pos = new Vector3(transform.position.x, transform.position.y + transform.localScale.y / 2, 0.0f);
            Instantiate(explode1, pos, Quaternion.identity);
            SoundController.PlaySound(soundsGame.soundExplode1);
        }

        if (collision.CompareTag("health"))
        {
            this.health += 100;
            if (health > maxHealth) health = maxHealth;
            Destroy(collision.gameObject);
            SoundController.PlaySound(soundsGame.soundItem);

        }

        if (collision.CompareTag("star"))
        {
            this.star += 10;
            Destroy(collision.gameObject);
            SoundController.PlaySound(soundsGame.soundItem);

        }
        if (collision.CompareTag("luckybox"))
        {
            Destroy(collision.gameObject);
            SoundController.PlaySound(soundsGame.soundItem);

        }
        if (collision.CompareTag("shieldItem"))
        {
            Destroy(collision.gameObject);
            SoundController.PlaySound(soundsGame.soundItem);
            if (shieldClone == null)
            {
                shieldClone = Instantiate(shield, transform.position, Quaternion.identity);
            }
            else
            {
                Destroy(shieldClone.gameObject);
                shieldClone = Instantiate(shield, transform.position, Quaternion.identity);
            }
        }
    }

    //------------------------------------------------------------------------------------------------------------------------------//


    void move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            flag = true;
            moursePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouPlayer = moursePos - transform.position;
        }
        if (Input.GetMouseButtonUp(0))
        {
            flag = false;
        }

        /////

        if (flag)
        {
            moursePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = moursePos - mouPlayer;
        }

        ///// xử lí đụng tường
        if (this.transform.position.x + this.transform.localScale.x/2 > MaxPoint.x)
        {
            this.transform.position = new Vector3(MaxPoint.x - this.transform.localScale.x / 2, transform.position.y, transform.position.z);
            moursePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouPlayer = moursePos - transform.position;
        }
        if (this.transform.position.y + this.transform.localScale.y/2  > MaxPoint.y)
        {
            this.transform.position = new Vector3(transform.position.x, MaxPoint.y - this.transform.localScale.y / 2, transform.position.z);
            moursePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouPlayer = moursePos - transform.position;
        }
        if (this.transform.position.x - this.transform.localScale.x / 2 < MinPoint.x)
        {
            this.transform.position = new Vector3(MinPoint.x + this.transform.localScale.x / 2, transform.position.y, transform.position.z);
            moursePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouPlayer = moursePos - transform.position;
        }
        if (this.transform.position.y - this.transform.localScale.y / 2 < MinPoint.y)
        {
            this.transform.position = new Vector3(transform.position.x, MinPoint.y + this.transform.localScale.y / 2, transform.position.z);
            moursePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouPlayer = moursePos - transform.position;
        }
        ///
    }
}
