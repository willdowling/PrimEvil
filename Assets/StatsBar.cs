using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
// class to keep the stats bars up to date
public class StatsBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxCapacity(float food)
    {
        slider.maxValue = food;
        slider.value = food;
    }

    public void SetCapacity(float food)
    {
        slider.value = food;
    }
}
