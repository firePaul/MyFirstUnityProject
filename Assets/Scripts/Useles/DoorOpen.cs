using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//щрю бепяхъ ме пюанрюер я дбепэлх онд пюгмшл сцкнл
//щрю бепяхъ ме пюанрюер я дбепэлх онд пюгмшл сцкнл
//щрю бепяхъ ме пюанрюер я дбепэлх онд пюгмшл сцкнл

public class DoorOpen : MonoBehaviour
{
    [SerializeField] Transform door;
    private bool IsOpen = false;
    private bool startOpen = false;
    private Vector3 Angle = new Vector3(0,-90,0);
    private float openSpeed = 1f;
    
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
            //float AngleY = gameObject.transform.localRotation.eulerAngles.y;
            //transform.localRotation = Quaternion.Euler(OpenAngle);
            transform.localRotation = Quaternion.Euler(Vector3.Lerp(transform.rotation.eulerAngles, transform.rotation.eulerAngles + new Vector3(0, -90, 0), openSpeed));
            //gameObject.transform.Rotate(Angle * openSpeed * Time.deltaTime);

            if (gameObject.transform.eulerAngles==door.rotation.eulerAngles-Angle)
            {
                startOpen = false;
                IsOpen = true;
            }
        }
    }

}
