using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }


    public GameObject bullet2;
    public GameObject Player;
    public float shootDelay = 3;
    public float lookUFO;
    public Vector3 LookDirection;

    public int heath = 200;
    public float timer = 1;
    public Vector3 direction;


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        shootDelay += Time.deltaTime;
        if (heath <= 0)
        {
            Destroy(gameObject);
        }

        transform.Translate(direction * Time.deltaTime / 0.4f);
        transform.rotation = Quaternion.identity;
        if (timer > 1)
        {
            timer = 0;
            newPosition();
        }
        if (shootDelay >= 2)
        {
            shootDelay = 0;

            LookDirection = Player.transform.position - transform.position;
            LookDirection.Normalize();
            lookUFO = Mathf.Atan2(LookDirection.y, LookDirection.x) * Mathf.Rad2Deg;

            var rotation = Quaternion.Euler(0f, 0f, lookUFO);
            GameObject bulletclone = Instantiate(bullet2, transform.position, rotation);
            bulletclone.GetComponent<Rigidbody2D>().velocity = LookDirection * 10.0f;
        }

    }


    public void newPosition()
    {
        direction = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            this.heath -= 10;
        }
    }

}
