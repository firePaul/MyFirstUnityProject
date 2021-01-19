using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float speed = 10;
    private void Awake()
    {
        Destroy(gameObject, 3);
    }

    private void Update()
    {
        transform.Translate(GameObject.Find("BulletStart").transform.forward * speed * Time.deltaTime);
    }
}
