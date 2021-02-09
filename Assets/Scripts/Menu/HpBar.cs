using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Slider hpslider;
        
    public void SetMaxHP(int health)
    {
        hpslider.maxValue = health;
        hpslider.value = health;
    }
    public void SetHP(int health)
    {
        hpslider.value = health;
    }
}
