using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoors : MonoBehaviour
{
    private bool IsOpen = false;
    private bool startOpen = false;
    private Transform doorL;
    private Transform doorR;
    [SerializeField] private float openSpeed = 0.01f;
    [SerializeField] private string dkey = null;

    private Vector3 defaultPos1;
    private Vector3 defaultPos2;
    private Vector3 localPosition2;
    private Vector3 localPosition4;


    private void Start()
    {
        doorL = this.gameObject.transform.GetChild(0);
        doorR = this.gameObject.transform.GetChild(1);
        defaultPos1 = doorL.transform.localPosition;
        defaultPos2 = doorR.transform.localPosition;
        localPosition2 = new Vector3(defaultPos1.x, defaultPos1.y, defaultPos1.z - 2f);
        localPosition4 = new Vector3(defaultPos2.x, defaultPos2.y, defaultPos2.z + 2f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (PlayerStats.keys.Contains(dkey))
            {
                startOpen = true;
                PlayerStats.keys.Remove(dkey);
            }           
        }
    }

    private void FixedUpdate()
    {
        if (startOpen && !IsOpen)
        {
            doorL.transform.localPosition = Vector3.Lerp(doorL.transform.localPosition, localPosition2, openSpeed);
            doorR.transform.localPosition = Vector3.Lerp(doorR.transform.localPosition, localPosition4, openSpeed);
            if (doorL.transform.localPosition == localPosition2 || doorR.transform.localPosition == localPosition4)
            {
                startOpen = false;
                IsOpen = true;
            }
        }
    }
}
