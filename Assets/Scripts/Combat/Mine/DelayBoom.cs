using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayBoom : MonoBehaviour
{
    [SerializeField] private int damage = 20;
    [SerializeField] private float delay = 0.5f;
    private List<Collider> targets = new List<Collider>();
    bool damagedone = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            targets.Add(other);
            StartCoroutine("DoDamage");
        }
    }

    IEnumerator DoDamage()
    {
        {
            yield return new WaitForSeconds(delay);
            Damage();
        }
    }

    void Damage()
    {
        if (!damagedone)
        {
            foreach (Collider someone in targets)
            {
                Vector3 direction = someone.gameObject.transform.position - gameObject.transform.position;
                someone.gameObject.GetComponent<ITakeDamage>().TakeDamage(damage);
                someone.attachedRigidbody.AddForce(new Vector3(direction.x, direction.y*400, direction.z*250), ForceMode.Impulse);
            }
            Destroy(transform.parent.gameObject, 0);
        }
        damagedone = true;
    }

    private void OnTriggerExit(Collider other)
    {
        targets.Remove(other);
    }
}
