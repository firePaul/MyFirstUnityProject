using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    private bool IsOpen = false;
    private bool startOpen = false;
    private Transform doorL;
    private Transform doorR;
    [SerializeField] private float openSpeed = 0.1f;

    private Vector3 defaultPos1;
    private Vector3 defaultPos2;
    //private Vector3 localPosition1;
    private Vector3 localPosition2;
    //private Vector3 localPosition3;
    private Vector3 localPosition4;


    private void Start()
    {
        doorL = this.gameObject.transform.GetChild(0);
        doorR = this.gameObject.transform.GetChild(1);
        defaultPos1 = doorL.transform.localPosition;
        defaultPos2 = doorR.transform.localPosition;
        //localPosition1 = new Vector3(defaultPos1.x - 0.0f, defaultPos1.y, defaultPos1.z); //0.05f
        localPosition2 = new Vector3(defaultPos1.x, defaultPos1.y, defaultPos1.z - 2f);
        //localPosition3 = new Vector3(defaultPos2.x - 0.0f, defaultPos2.y, defaultPos2.z); //0.05f
        localPosition4 = new Vector3(defaultPos2.x, defaultPos2.y, defaultPos2.z + 2f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            startOpen = true;
        }
    }

    private void FixedUpdate()
    {
        if (startOpen && !IsOpen)
        {
            //doorL.transform.localPosition = Vector3.Lerp(doorL.transform.localPosition, localPosition1, openSpeed * 50 * Time.deltaTime);
            //doorR.transform.localPosition = Vector3.Lerp(doorR.transform.localPosition, localPosition3, openSpeed * 50 * Time.deltaTime);
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
