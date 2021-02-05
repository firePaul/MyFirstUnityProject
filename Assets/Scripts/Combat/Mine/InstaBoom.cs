using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaBoom : MonoBehaviour, ITakeDamage
{
    [SerializeField] private int damage = 20;
    [SerializeField] private int hp = 200;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 direction = other.gameObject.transform.position - gameObject.transform.position;
            other.gameObject.GetComponent<ITakeDamage>().TakeDamage(damage);
            other.attachedRigidbody.AddForce(new Vector3(direction.x, direction.y * 400, direction.z * 250), ForceMode.Impulse);
            Destroy(gameObject, 0);
        }
        if (other.CompareTag("Enemy"))
        {
            Vector3 direction = other.gameObject.transform.position - gameObject.transform.position;
            other.gameObject.GetComponent<ITakeDamage>().TakeDamage(damage);
            other.attachedRigidbody.AddForce(new Vector3(direction.x, direction.y * 400, direction.z * 250), ForceMode.Impulse);
            Destroy(gameObject, 0);
        }
    }
   
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Death();
        }
    }
    private void Death()
    {
        Destroy(gameObject, 0);
    }
}
