using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTrap : MonoBehaviour
{
    [SerializeField] int damage = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 direction = other.gameObject.transform.position - gameObject.transform.position;
            other.gameObject.GetComponent<ITakeDamage>().TakeDamage(damage);
            other.attachedRigidbody.AddForce(new Vector3(direction.x, direction.y * 400, direction.z * 250), ForceMode.Impulse);
        }
    }
}
