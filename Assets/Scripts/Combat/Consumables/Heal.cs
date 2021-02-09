using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] private int heal = 20;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (PlayerStats.curhp < PlayerStats.maxhp)
            {
                other.GetComponent<ITakeDamage>().TakeDamage(-heal);
                Destroy(gameObject);
            }
        }        
    }
}
