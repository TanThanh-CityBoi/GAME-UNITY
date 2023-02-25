using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float Timer;
    public bool flag = false;
    public GameObject Pos1, Pos2, Pos3, Pos4, Pos5, Pos6;
    public Vector3 MaxPoint, MinPoint;
    ///

    public Path movingPath;
    public float movingSpeed;
    public List<GameObject> E2Lists = new List<GameObject>();
    public List<int> pointIndexs = new List<int>();
    /// 
    ///
    public GameObject starPos;

    // Start is called before the first frame update

    void Start()
    {
        Timer = 0;
        MaxPoint = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0.0f));
        MinPoint = Camera.main.ScreenToWorldPoint(Vector3.zero);
        //
        movingSpeed = 2.0f;
        //currentPoint = 0;
    }

    //---------------------------------------------------------------------------------------------------------------------------//

    public void Move1(List<EnemyData> enemys)
    {
            if (flag)
            {
                flag = false;
                GameObject e1Clone = Instantiate(enemys[0].prefab, Pos1.transform.position, Quaternion.identity);
                GameObject e2Clone = Instantiate(enemys[0].prefab, Pos2.transform.position, Quaternion.identity);
                GameObject e3Clone = Instantiate(enemys[0].prefab, Pos3.transform.position, Quaternion.identity);

                e1Clone.GetComponent<Rigidbody2D>().velocity = new Vector3(0.0f, -1.0f, 0.0f) * 3.0f;
                e2Clone.GetComponent<Rigidbody2D>().velocity = new Vector3(0.0f, -1.0f, 0.0f) * 3.0f;
                e3Clone.GetComponent<Rigidbody2D>().velocity = new Vector3(0.0f, -1.0f, 0.0f) * 3.0f;
            }
            else
            {
                flag = true;
                GameObject e4Clone = Instantiate(enemys[1].prefab, Pos4.transform.position, Quaternion.identity);
                GameObject e5Clone = Instantiate(enemys[1].prefab, Pos5.transform.position, Quaternion.identity);
                GameObject e6Clone = Instantiate(enemys[1].prefab, Pos6.transform.position, Quaternion.identity);

                e4Clone.GetComponent<Rigidbody2D>().velocity = new Vector3(0.0f, -1.0f, 0.0f) * 3.0f;
                e5Clone.GetComponent<Rigidbody2D>().velocity = new Vector3(0.0f, -1.0f, 0.0f) * 3.0f;
                e6Clone.GetComponent<Rigidbody2D>().velocity = new Vector3(0.0f, -1.0f, 0.0f) * 3.0f;
            }
    }

    public void CreateEnemy2(List<EnemyData> enemys)
    {

            GameObject e2Clone = Instantiate(enemys[0].prefab, movingPath.ListPoints[0].transform.position, Quaternion.identity);
            E2Lists.Add(e2Clone);
            pointIndexs.Add(0);
    }
    public void Move2()
    {

        for(int i = 0; i < E2Lists.Count; i++)
        {
            if(E2Lists is null)
            {
                return;
            }
            if (E2Lists[i] == null)
            {
                E2Lists.RemoveAt(i);
                pointIndexs.RemoveAt(i);
                i--;/////////////////////
                continue;
            }
            float distance = Vector3.Distance(movingPath.ListPoints[pointIndexs[i]].transform.position, E2Lists[i].transform.position);

            if (distance <= 0.25f)
            {
                pointIndexs[i] ++;
                if (pointIndexs[i] >= movingPath.ListPoints.Count)
                {
                    Destroy(E2Lists[i]);
                    E2Lists.RemoveAt(i);
                    pointIndexs.RemoveAt(i);
                    i--;//////////
                    continue;
                }
            }

            Vector3 direction = movingPath.ListPoints[pointIndexs[i]].transform.position - E2Lists[i].transform.position;
            direction.Normalize();
            E2Lists[i].GetComponent<Rigidbody2D>().velocity = direction * movingSpeed;

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
        if (e3Clone.transform.position.y > MaxPoint.y - (MaxPoint.y - MinPoint.y)/8)
        {
            e3Clone.transform.position += new Vector3(0.0f, -1.0f, 0.0f) * 3.0f * Time.deltaTime;
        }
        return false;
    }
}
