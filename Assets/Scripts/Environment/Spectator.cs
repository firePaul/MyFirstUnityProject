using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spectator : MonoBehaviour
{
    [SerializeField] private int hp = 200;
    [SerializeField] private float speed = 10f;
    private Collider spectateTarget;

    bool spectate = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            spectate = true;
            spectateTarget = other;
            Vector3 TargetD = spectateTarget.gameObject.transform.position - transform.position;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(TargetD), Time.deltaTime * speed);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (spectate)
        {
            Vector3 TargetD = spectateTarget.gameObject.transform.position - transform.position;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(TargetD), Time.deltaTime * speed);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            spectate = false;
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
