using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHP : MonoBehaviour, ITakeDamage
{
    [SerializeField] private int hp = 200;

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Death();
        }
    }
    private void Death()
    {
        Destroy(transform.parent.gameObject, 0);
    }
}
