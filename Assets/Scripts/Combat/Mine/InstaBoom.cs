using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaBoom : MonoBehaviour
{
    [SerializeField] private int damage = 20;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<ITakeDamage>().TakeDamage(damage);
            Destroy(transform.parent.gameObject, 0);
        }
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<ITakeDamage>().TakeDamage(damage * 5);
            Destroy(transform.parent.gameObject, 0);
        }
    }
}
