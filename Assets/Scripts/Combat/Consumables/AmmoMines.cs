using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoMines : MonoBehaviour
{
    [SerializeField] private int AmMines = 10;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<IAmmo>().MineChange(AmMines);
            Destroy(gameObject);
        }        
    }
}
