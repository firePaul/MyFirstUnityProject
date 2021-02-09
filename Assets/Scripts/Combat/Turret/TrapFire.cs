using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapFire : MonoBehaviour
{
    [SerializeField] private float AtackSpeed = 1f;
    [SerializeField] private GameObject bullet = null;
    [SerializeField] private Transform bulletStartPosition = null;

    private void Start()
    {
        StartCoroutine("StartFire");
    }

    IEnumerator StartFire()
    {
        for (; ;)
        {
            yield return new WaitForSeconds(AtackSpeed);
            var bul = Instantiate(bullet, bulletStartPosition.position, transform.rotation);
        }       
    }
}
