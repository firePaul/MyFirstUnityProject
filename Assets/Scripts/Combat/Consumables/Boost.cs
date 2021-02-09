using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    [SerializeField] private float speedmult = 1.5f;
    [SerializeField] private float duration = 10;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponentInChildren<ISpeed>().SpeedChange(speedmult,duration);
            Destroy(gameObject);
        }
    }
}
