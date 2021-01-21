using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBullets : MonoBehaviour
{
    [SerializeField] private int AmmoBul = 20;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<IAmmo>().BulletChange(AmmoBul);
            Destroy(gameObject);
        }       
    }
}
