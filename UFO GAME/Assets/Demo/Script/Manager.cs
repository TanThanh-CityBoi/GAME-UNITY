using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject YouWinText;
    public GameObject YouLoseText;
    public Player player;
    public enemy2 e2;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        e2 = (enemy2)FindObjectOfType(typeof(enemy2));
        if (player.heath <= 0)
        {
            YouLoseText.SetActive(true);
        }
        else if (e2.heath <= 0)
        {
            YouWinText.SetActive(true);
        }

    }
}
