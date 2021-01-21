using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ITakeDamage
{
    [SerializeField] private int hp = 100;

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
        Destroy(gameObject, 0);
    }
}
