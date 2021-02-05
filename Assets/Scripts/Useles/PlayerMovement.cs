using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2;
    [SerializeField] private GameObject bullet = null;
    [SerializeField] private Transform bulletStartPosition = null;
    //[SerializeField] private int hp = 100;
    private Vector3 direction = Vector3.zero;
    private bool fire = false;
    void FixedUpdate()
    {
        var s = speed * direction * Time.fixedDeltaTime;
        transform.Translate(s);
        if (fire) Fire();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject.Find("Player").transform.Rotate(0, 90, 0);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject.Find("Player").transform.Rotate(0, -90, 0);
        }
        if (Input.GetMouseButtonDown(0))
        {
            fire = true;
        }
        
    }

    private void Fire()
    {
        fire = false;
        var bul = Instantiate(bullet, bulletStartPosition.position, Quaternion.identity);
    }
}
