using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Background"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("enemy1"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("enemy2"))
        {
            Destroy(gameObject);
        }
    }
}
