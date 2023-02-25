using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public GameObject item;
    public int heath = 20;
    public float timer = 1;
    public Vector3 direction;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(heath <= 0)
        {
            Destroy(gameObject);
            Instantiate(item, transform.position, Quaternion.identity);
        }

        transform.Translate(direction * Time.deltaTime/0.4f);
        transform.rotation = Quaternion.identity;
        if (timer > 1)
        {
            timer = 0;
            newPosition();
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
        if (collision.gameObject.CompareTag("Background"))
        {
            newPosition();
        }
    }
}
