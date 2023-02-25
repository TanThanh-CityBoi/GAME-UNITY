using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode2 : MonoBehaviour
{
    // Start is called before the first frame update
    float Timer;
    void Start()
    {
        Timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= 0.85f)
        {
            Destroy(gameObject);
        }
        transform.Translate(translation: Vector3.down * 3.0f * Time.deltaTime);
    }
}
