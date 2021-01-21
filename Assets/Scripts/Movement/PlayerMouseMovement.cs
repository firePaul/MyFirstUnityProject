using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseMovement : MonoBehaviour
{
    [SerializeField] private float MouseSensitivity = 1200f;
    [SerializeField] private Transform PlayerBody;
    [SerializeField] private float speed = 2;    

    private Vector3 direction = Vector3.zero;
    float xRotation = 0f;

    void FixedUpdate()
    {
        var s = speed * direction * Time.fixedDeltaTime;
        GameObject.Find("Player").transform.Translate(s);
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        PlayerBody.Rotate(Vector3.up * mouseX);
    }

}
