using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenV2 : MonoBehaviour
{
    private bool IsOpen = false;
    private bool startOpen = false;
    
    [SerializeField] private float openSpeed = 0.01f;
    [SerializeField] private float DoorOpenAngle = 90f;

    private Vector3 defaultRot;
    private Vector3 openRot;

    private void Start()
    {
        defaultRot = transform.eulerAngles;       
        openRot = new Vector3(defaultRot.x, defaultRot.y - DoorOpenAngle, defaultRot.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            startOpen = true;
        }
    }

    private void Update()
    {
        if (startOpen && !IsOpen)
        {
            transform.rotation = Quaternion.Euler(Vector3.Lerp(transform.rotation.eulerAngles, openRot, openSpeed));
            if(openRot.y < 0) 
            {
                openRot.y = 360 - DoorOpenAngle;
                if (gameObject.transform.eulerAngles == openRot)
                {
                    startOpen = false;
                    IsOpen = true;
                }
            }
            
            if (gameObject.transform.eulerAngles == openRot)
            {
                startOpen = false;
                IsOpen = true;
            }
        }
    }
}
