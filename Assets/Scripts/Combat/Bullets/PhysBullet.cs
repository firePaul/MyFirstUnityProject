using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysBullet : MonoBehaviour
{
    [SerializeField] private Rigidbody pb = null;
    [SerializeField] private float speed = 20f;
    [SerializeField] private int damage = 50;

    private void Awake()
    {
        Destroy(gameObject, 15);
        Shoot();
    }

    private void Shoot()
    {
        pb.AddForce(transform.forward * speed, ForceMode.Force);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<ITakeDamage>().TakeDamage(damage / 5);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("RobotEnemy"))
        {
            other.GetComponentInParent<ITakeDamage>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<ITakeDamage>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Mine"))
        {
            other.GetComponent<ITakeDamage>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
