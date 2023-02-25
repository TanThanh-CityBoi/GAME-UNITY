using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Vector3 MaxPoint, MinPoint;
    // Start is called before the first frame update
    void Start()
    {
        MaxPoint = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0.0f));
        MinPoint = Camera.main.ScreenToWorldPoint(Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        move();
        Remove();
    }

    public void Remove()
    {
        if (transform.position.x - 1.0f > MaxPoint.x || transform.position.x + 1.0f < MinPoint.x || transform.position.y - 1.0f > MaxPoint.y || transform.position.y + 1.0f < MinPoint.y)
        {
            Destroy(gameObject);
        }
    }

    public void move()
    {
        transform.position += new Vector3(0.0f, -1.0f, 0.0f) * 4.0f * Time.deltaTime;
    }
}
