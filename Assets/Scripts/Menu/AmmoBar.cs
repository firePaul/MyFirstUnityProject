using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBar : MonoBehaviour
{
    public Slider amslider;

    public void SetMaxAmmo(int ammo)
    {
        amslider.maxValue = ammo;
        amslider.value = ammo;
    }
    public void SetAmmo(int ammo)
    {
        amslider.value = ammo;
    }
}
