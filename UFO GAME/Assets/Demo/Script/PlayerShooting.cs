using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public GameObject bullet;
    private Vector2 LookDirection;
    private float lookUFO;


    // Update is called once per frame
    void Update()
    {
        LookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookUFO = Mathf.Atan2(LookDirection.y, LookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, lookUFO - 90f);

        if (Input.GetMouseButtonDown(0))
        {
            FireBullet();
        }

    }


    void FireBullet()
    {
        var rotation = Quaternion.Euler(0f, 0f, lookUFO);
        GameObject fireBullet = Instantiate(bullet, this.transform.position, rotation);
        fireBullet.GetComponent<Rigidbody2D>().velocity = this.transform.up * 10f;
    }

}
