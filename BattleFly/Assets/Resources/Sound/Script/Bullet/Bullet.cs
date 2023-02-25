using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{

    public float speed = 10.0f;
    public float dame = 25;
    public Vector3 MaxPoint, MinPoint;


    public abstract void RemoveBullet();
    public abstract void move();

    public abstract void Fire(List<GameObject> GunPos);
}
