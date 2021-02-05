using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour, ITakeDamage
{
    [SerializeField] private int hp = 5000;
    private NavMeshAgent enemy = null;
    [SerializeField] private Transform droppoint = null;
    [SerializeField] private GameObject drop1 = null;
    [SerializeField] private GameObject drop2 = null;
    [SerializeField] private GameObject drop3 = null;
    [SerializeField] private float AtackSpeed = 0.25f;
    [SerializeField] private GameObject bullet = null;
    [SerializeField] private Transform bulletStartPosition = null;

    private GameObject player = null;
    private bool drop = false;
    private RaycastHit rayHit;
    private float sigthdist = 100f;
    private bool fire = false;

    public void Awake()
    {
        droppoint = gameObject.transform.GetChild(0);
        enemy = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Update()
    {
        if (Physics.Raycast(transform.position, player.transform.position - transform.position, out rayHit, sigthdist))
        {
            if (rayHit.collider.gameObject.tag == "Player")
            {                
                enemy.stoppingDistance = 30f;
                enemy.SetDestination(player.transform.position);
                player = rayHit.collider.gameObject;
                gameObject.transform.LookAt(player.transform);
                gameObject.transform.GetChild(6).LookAt(player.transform);
            }
            if (!fire && rayHit.collider.gameObject.tag == "Player")
            {
                fire = true;
                StopAllCoroutines();
                StartCoroutine("StartFire");
            }
        }
    }

    IEnumerator StartFire()
    {
        if (fire)
        {
            for (; ; )
            {
                
                yield return new WaitForSeconds(AtackSpeed);
                var bul = Instantiate(bullet, bulletStartPosition.position, transform.rotation);
                if (!fire) break;
            }
        }
    }

    public void FixedUpdate()
    {

    }
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            drop = true;
            Death();
        }
    }
    private void Death()
    {
        if (drop)
        {
            float rnd1 = Random.Range(1, 100);
            float rnd2 = Random.Range(1, 100);
            float rnd3 = Random.Range(1, 100);
            if (rnd1 <= 20)
            {
                Instantiate(drop1, new Vector3(gameObject.transform.position.x, 1, gameObject.transform.position.z), droppoint.rotation);
            }
            if (rnd2 <= 10)
            {
                Instantiate(drop2, new Vector3(gameObject.transform.position.x, 1, gameObject.transform.position.z), droppoint.rotation);
            }
            if (rnd3 <= 5)
            {
                Instantiate(drop3, new Vector3(gameObject.transform.position.x, 1, gameObject.transform.position.z), droppoint.rotation);
            }
        }
        Destroy(gameObject);
    }
}
