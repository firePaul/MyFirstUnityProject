using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostBar : MonoBehaviour
{
    public Slider bsslider;

    public void SetMaxBoost(int duration)
    {
        bsslider.maxValue = duration;
        bsslider.value = duration;
    }
    public void SetBoost(int duration)
    {
        bsslider.value = duration;
    }
}
