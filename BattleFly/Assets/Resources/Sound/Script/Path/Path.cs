using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{

    public Color StartPointColor = Color.red;
    public Color PathColor = Color.white;
    public Color PointColor = Color.yellow;

    public List<Transform> ListPoints = new List<Transform>();

    /*private void OnDrawGizmos()
    {
        Gizmos.color = StartPointColor;
        ListPoints.Clear();

        foreach (Transform p in this.GetComponentInChildren<Transform>())
        {
            if (p != this.transform) ListPoints.Add(p);
        }

        for (int i = 0; i < ListPoints.Count; i++)
        {
            if (i > 0)
            {
                Gizmos.DrawLine(ListPoints[i - 1].position, ListPoints[i].position);
                Gizmos.color = PathColor;
                Gizmos.DrawSphere(ListPoints[i].position, 0.15f);
                Gizmos.color = PointColor;
            }
            else
            {
                Gizmos.DrawSphere(ListPoints[0].position, 0.15f);
                Gizmos.color = PathColor;
            }
        }
    }*/
}
