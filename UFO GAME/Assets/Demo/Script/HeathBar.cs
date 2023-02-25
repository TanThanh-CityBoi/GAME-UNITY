using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathBar : MonoBehaviour
{

    public Slider slider;
       
    public void SetMaxHeath(float heath)
    {
        slider.maxValue = heath;
        slider.value = heath;
    }

    public void SetHeath(float heath)
    {
        slider.value = heath;
    }
}
