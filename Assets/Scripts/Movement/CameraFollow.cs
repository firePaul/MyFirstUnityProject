using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public float MouseSensitivity = 1200f;
    float mouseX;
    float mouseY;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        mouseX += Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        mouseY -= Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        mouseY = Mathf.Clamp(mouseY, -90f, 90f);

        transform.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        Target.rotation = Quaternion.Euler(0, mouseX, 0);
    }

}
