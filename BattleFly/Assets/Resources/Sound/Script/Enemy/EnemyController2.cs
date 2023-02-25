using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : MonoBehaviour
{
    public float Timer;
    public bool flag = false;
    public Vector3 MaxPoint, MinPoint;
    ///

    public Path movingPath, movingPath2;


    public float movingSpeed;
    public List<GameObject> E1Lists = new List<GameObject>();
    public List<GameObject> E2Lists = new List<GameObject>();

    public List<int> pointIndexs = new List<int>();
    public List<int> pointIndexs2 = new List<int>();

    /// 
    ///
    public GameObject starPos;

    // Start is called before the first frame update

    void Start()
    {
        MaxPoint = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0.0f));
        MinPoint = Camera.main.ScreenToWorldPoint(Vector3.zero);
        //
        movingSpeed = 3.0f;
        //currentPoint = 0;
    }

    //---------------------------------------------------------------------------------------------------------------------------//

    public void Move1()
    {
        for (int i = 0; i < E1Lists.Count; i++)
        {
            if (E1Lists is null)
            {
                return;
            }
            if (E1Lists[i] == null)
            {
                E1Lists.RemoveAt(i);
                pointIndexs.RemoveAt(i);
                i--;/////////////////////
                continue;
            }
            float distance = Vector3.Distance(movingPath.ListPoints[pointIndexs[i]].transform.position, E1Lists[i].transform.position);

            if (distance <= 0.25f)
            {
                pointIndexs[i]++;
                if (pointIndexs[i] >= movingPath.ListPoints.Count)
                {
                    Destroy(E1Lists[i]);
                    E1Lists.RemoveAt(i);
                    pointIndexs.RemoveAt(i);
                    i--;//////////
                    continue;
                }
            }

            Vector3 direction = movingPath.ListPoints[pointIndexs[i]].transform.position - E1Lists[i].transform.position;
            direction.Normalize();
            E1Lists[i].GetComponent<Rigidbody2D>().velocity = direction * movingSpeed;

        }
    }

    int i = 0;
    public void CreateEnemy1(List<EnemyData> enemys)
    {
        GameObject e1Clone = Instantiate(enemys[i].prefab, movingPath.ListPoints[0].transform.position, Quaternion.identity);
        E1Lists.Add(e1Clone);
        pointIndexs.Add(0);

        if (i < enemys.Count - 1) i++;
        else i = 0;
    }

    //------------------------------------------------------------------------------------------------------------------------//
    public void CreateEnemy2(List<EnemyData> enemys)
    {

        GameObject e2Clone = Instantiate(enemys[0].prefab, movingPath2.ListPoints[0].transform.position, Quaternion.identity);
        E2Lists.Add(e2Clone);
        pointIndexs2.Add(0);
    }

    public void Move2()
    {

        for (int i = 0; i < E2Lists.Count; i++)
        {
            if (E2Lists is null)
            {
                return;
            }
            if (E2Lists[i] == null)
            {
                E2Lists.RemoveAt(i);
                pointIndexs2.RemoveAt(i);
                i--;/////////////////////
                continue;
            }
            float distance = Vector3.Distance(movingPath2.ListPoints[pointIndexs2[i]].transform.position, E2Lists[i].transform.position);

            if (distance <= 0.25f)
            {
                pointIndexs2[i]++;
                if (pointIndexs2[i] >= movingPath2.ListPoints.Count)
                {
                    Destroy(E2Lists[i]);
                    E2Lists.RemoveAt(i);
                    pointIndexs2.RemoveAt(i);
                    i--;//////////
                    continue;
                }
            }

            Vector3 direction = movingPath2.ListPoints[pointIndexs2[i]].transform.position - E2Lists[i].transform.position;
            direction.Normalize();
            // E2Lists[i].GetComponent<Rigidbody2D>().velocity = direction * movingSpeed;
            E2Lists[i].transform.position += direction * movingSpeed * Time.deltaTime;
        }

    }



    //-------------------------------------------------------------------------------------------------------//
    public bool created = false;
    public GameObject e3Clone;
    public bool Move3(List<EnemyData> enemys)
    {
        if (!created)
        {
            e3Clone = Instantiate(enemys[0].prefab, starPos.transform.position, Quaternion.identity);
            created = true;
        }
        if (e3Clone == null)
        {
            return true;
        }
        if (e3Clone.transform.position.y > MaxPoint.y - (MaxPoint.y - MinPoint.y) / 8)
        {
            e3Clone.transform.position += new Vector3(0.0f, -1.0f, 0.0f) * 3.0f * Time.deltaTime;
        }
        return false;
    }
}
