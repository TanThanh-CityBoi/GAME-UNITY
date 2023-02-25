using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float health;
    public GameObject Player;
    public GameObject explode;
    // Start is called before the first frame update
    void Start()
    {
        health = 500;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position;
        if (health <= 0) Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("enemy") || collision.CompareTag("bullet3") || collision.CompareTag("bullet4") || collision.CompareTag("bullet5"))
        {
            health -= 100;
            Vector3 pos = transform.position + (collision.transform.position - transform.position) / 2;
            Instantiate(explode, pos, Quaternion.identity);
        }
    }
}
