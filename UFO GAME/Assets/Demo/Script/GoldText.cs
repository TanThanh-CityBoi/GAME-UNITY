using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldText : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Gold: 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setUp(int gold)
    {
        text.text = "Gold: " + gold.ToString();
    }
}
