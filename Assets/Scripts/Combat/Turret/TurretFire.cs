using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFire : MonoBehaviour
{
    [SerializeField] private float RotationSpeed = 10f;
    [SerializeField] private float AtackSpeed = 2;
    [SerializeField] private GameObject bullet = null;
    [SerializeField] private Transform bulletStartPosition = null;

    bool fire = false;
    bool spectate = false;
    private Collider spectateTarget;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            spectate = true;
            fire = true;
            spectateTarget = other;
            Vector3 TargetD = spectateTarget.gameObject.transform.position - transform.position;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(TargetD), Time.deltaTime * RotationSpeed);
            StartCoroutine("StartFire");
        }
    }
    IEnumerator StartFire()
    {
        {
            if (fire)
            {
                for (; ;)
                {
                    yield return new WaitForSeconds(AtackSpeed);
                    var bul = Instantiate(bullet, bulletStartPosition.position, transform.rotation);
                    if (!fire) break;
                }                                    
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {       
        if (spectate)
        {
            Vector3 TargetD = spectateTarget.gameObject.transform.position - transform.position;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(TargetD), Time.deltaTime * RotationSpeed);           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            spectate = false;
            fire = false;
        }
    }
}
