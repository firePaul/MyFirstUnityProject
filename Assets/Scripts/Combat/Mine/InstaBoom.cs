using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaBoom : MonoBehaviour, ITakeDamage
{
    [SerializeField] private int hp = 20;
    [SerializeField] private int damage = 20;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<ITakeDamage>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<ITakeDamage>().TakeDamage(damage * 5);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
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
