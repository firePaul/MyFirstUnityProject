using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, ITakeDamage
{
    [SerializeField] private int hp = 100;
    [SerializeField] private GameObject drop1 = null;
    [SerializeField] private GameObject drop2 = null;
    [SerializeField] private GameObject drop3 = null;
    private GameObject player;
    private float sigthdist=25f;
    RaycastHit rayHit;
    Color rayColor = Color.green;
    NavMeshAgent agent;

    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, player.transform.position- transform.position, out rayHit, sigthdist))
        {
            if (rayHit.collider.gameObject.tag == "Player")
            {
                agent.SetDestination(player.transform.position);
                player = rayHit.collider.gameObject;
            }
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
        float rnd1 = Random.Range(1, 100);
        float rnd2 = Random.Range(1, 100);
        float rnd3 = Random.Range(1, 100);
        if (rnd1 <= 80)
        {
            Instantiate(drop1, transform.position, transform.rotation);
        }
        if (rnd2 <= 80)
        {
            Instantiate(drop2, transform.position, transform.rotation);
        }
        if (rnd3 <= 80)
        {
            Instantiate(drop3, transform.position, transform.rotation);
        }
        Destroy(gameObject, 0);
    }
}
