using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MDoors : MonoBehaviour
{
    private bool IsOpen = false;
    private bool startOpen = false;

    [SerializeField] private float openSpeed = 0.1f;

    private Vector3 defaultPos;
    private Vector3 position1;
    private Vector3 position2;


    private void Start()
    {
        defaultPos = gameObject.transform.position;
        position1 = new Vector3(defaultPos.x - 0.05f, defaultPos.y, defaultPos.z);
        position2 = new Vector3(position1.x, defaultPos.y, defaultPos.z - 1f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            startOpen = true;
        }
        if (startOpen && !IsOpen) { transform.position = Vector3.Lerp(gameObject.transform.position, position1, openSpeed * 10); }
    }

    private void Update()
    {
        if (startOpen && !IsOpen)
        {           
            transform.position = Vector3.Lerp(gameObject.transform.position, position2, openSpeed);
            if (gameObject.transform.position == position2)
            {
                startOpen = false;
                IsOpen = true;
            }
        }
    }
}


