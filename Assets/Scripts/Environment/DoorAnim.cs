using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnim : MonoBehaviour
{
    private Animator _doors = null;

    private void Start()
    {
        _doors = gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            _doors.SetBool("SomeoneNearby", true);
        }       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            _doors.SetBool("SomeoneNearby", false);
        }
    }
}
