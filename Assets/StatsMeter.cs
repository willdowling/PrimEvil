using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsMeter : MonoBehaviour
{

    // class to keep the stats bars up to date
    public Slider energy;
    public Slider bladder;

    public void SetMaxEnergy(float ener)
    {
        energy.maxValue = ener;
        energy.value = ener;
    }
    public void SetMaxBladder(float blad)
    {
        bladder.maxValue = blad;
        bladder.value = blad;
    }

    public void SetEnergy(float ener)
    {
        energy.value = ener;
    }
    public void SetBladder(float blad)
    {
        bladder.value = blad;
    }

}
