using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Init();
        heathBar.SetMaxHeath(heath);
    }
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject bullet2;
    public GameObject gold;
    public GameObject direct;
    public GameObject camera;
    public float vA, vS, vD, vW;
    public float aA, aS, aD, aW;
    public float s1, s2;
    public float heath = 200;
    public HeathBar heathBar;
    public int golds = 0;
    public GoldText goldText;

    // Update is called once per frame
    void Update()
    {
        this.Move();
        heathBar.SetHeath(heath);
        this.direct.transform.position = this.transform.position;
        this.camera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.camera.transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("PickUp"))
        {
            golds++;
            goldText.setUp(golds);
            Destroy(col.gameObject);
            float PosX = UnityEngine.Random.Range(-20.0f, 20.0f);
            float PosY = UnityEngine.Random.Range(-20.0f, 20.0f);
            Instantiate(this.gold, new Vector3(PosX, PosY), Quaternion.identity);
        }
        if (col.gameObject.CompareTag("bullet2"))
        {
            heath -= 20;
        }
        if (col.gameObject.CompareTag("item"))
        {
            heath += 20;
            Destroy(col.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy1"))
        {
            heath -= 50;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("enemy2"))
        {
            heath = 0;
        }
    }

    public void Init()
    {
        float goldX = UnityEngine.Random.Range(-20.0f, 20.0f);
        float goldY = UnityEngine.Random.Range(-20.0f, 20.0f);
        Instantiate(this.gold, new Vector3(goldX, goldY), Quaternion.identity);

        float e1X = UnityEngine.Random.Range(-20.0f, 20.0f);
        float e1Y = UnityEngine.Random.Range(-20.0f, 20.0f);
        Instantiate(enemy1, new Vector3(e1X, e1Y), Quaternion.identity);

        float e2X = UnityEngine.Random.Range(-20.0f, 20.0f);
        float e2Y = UnityEngine.Random.Range(-20.0f, 20.0f);
        Instantiate(enemy2, new Vector3(e2X, e2Y), Quaternion.identity);

    }


    //----------------------------------------------------------------------------------------------------------------------------//

    void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            aD = 10.0f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            aA = -10.0f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            aW = 10.0f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            aS = -10.0f;
        }

        //---------------------------------------------------------------------//

        if (Input.GetKeyUp(KeyCode.D))
        {
            aD = -10.0f;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            aA = 10.0f;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            aW = -10.0f;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            aS = 10.0f;
        }

        vD += aD * Time.deltaTime;
        vA += aA * Time.deltaTime;
        vW += aW * Time.deltaTime;
        vS += aS * Time.deltaTime;

        //-----------------------------------------------------------------------//

        if (Math.Round(vA + vD) == 0 && vA * vD < 0)
        {
            vD = 0;
            aD = 0;
            vA = 0;
            aA = 0;
        }
        if (Math.Round(vS + vW) == 0 && vW * vS < 0)
        {
            vW = 0;
            aW = 0;
            vS = 0;
            aS = 0;
        }
        if (vD < 0)
        {
            vD = 0;
            aD = 0;
        }

        if (vA > 0)
        {
            vA = 0;
            aA = 0;
        }

        if (vW < 0)
        {
            vW = 0;
            aW = 0;
        }
        if (vS > 0)
        {
            vS = 0;
            aS = 0;
        }

        //----------------------------------------------------------------------------------//

        this.s1 = this.vA * Time.deltaTime + 0.5f * this.aA * Time.deltaTime * Time.deltaTime + this.vD * Time.deltaTime + 0.5f * this.aD * Time.deltaTime * Time.deltaTime;
        this.s2 = this.vW * Time.deltaTime + 0.5f * this.aW * Time.deltaTime * Time.deltaTime + this.vS * Time.deltaTime + 0.5f * this.aS * Time.deltaTime * Time.deltaTime;

        this.transform.position += new Vector3(this.s1, this.s2);
    }
}
