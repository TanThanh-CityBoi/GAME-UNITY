using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy8 : Enemy
{
    // Start is called before the first frame update

    public GameObject E1;
    public GameObject E2;
    public GameObject E3;
    public GameObject E4;

    public GameObject TargetRotation;

    void Start()
    {
        MaxPoint = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0.0f));
        MinPoint = Camera.main.ScreenToWorldPoint(Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        Remove();
        Move();
    }
    public float GetRotation()
    {
        Vector3 direction = TargetRotation.transform.position - transform.position;
        direction.Normalize();
        float result = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        return result;
    }
    public void Move()
    {
        if (TargetRotation != null)
        {
            Quaternion targetRotation = Quaternion.Euler(0.0f, 0.0f, GetRotation());
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, 2.0f * Time.deltaTime);
        }
        if (E1 != null) E1.transform.rotation = Quaternion.identity;
        if (E2 != null) E2.transform.rotation = Quaternion.identity;
        if (E3 != null) E3.transform.rotation = Quaternion.identity;
        if (E4 != null) E4.transform.rotation = Quaternion.identity;
    }
    public override void Remove()
    {

        if (transform.position.x - 5.0f > MaxPoint.x || transform.position.x + 5.0f < MinPoint.x || transform.position.y - 5.0f > MaxPoint.y || transform.position.y + 5.0f < MinPoint.y)
        {
            ;  Destroy(gameObject);
        }

        if(E4 == null)
        {
            Destroy(gameObject);
        }
    }
}
