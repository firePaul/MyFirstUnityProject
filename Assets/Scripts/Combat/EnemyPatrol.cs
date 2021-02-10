using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour, ITakeDamage, IPatrol
{
    [SerializeField] private int hp = 100;
    private NavMeshAgent enemy=null;
    [SerializeField] private Transform droppoint = null;
    [SerializeField] private GameObject drop1 = null;
    [SerializeField] private GameObject drop2 = null;
    [SerializeField] private GameObject drop3 = null;
    [SerializeField] private float AtackSpeed = 1;
    [SerializeField] private GameObject bullet = null;
    [SerializeField] private Transform bulletStartPosition = null;

    private List<Transform> patrolPoints = new List<Transform>();
    
    private GameObject player = null;
    private int point=0;
    private bool drop = false;
    private RaycastHit rayHit;
    private float sigthdist = 25f;
    private bool patrol=false;
    private bool fire = false;

    public void Awake()
    {
        droppoint = gameObject.transform.GetChild(0);
        enemy = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        patrol = true;
    }
    public void SetPatrolPoints(List<Transform> points)
    {
        foreach (Transform point in points)
        {
            patrolPoints.Add(point);
        }      
    }

    public void Update()
    {
        if (Physics.Raycast(transform.position, player.transform.position - transform.position, out rayHit, sigthdist))
        {
            if (rayHit.collider.gameObject.tag == "Player")
            {
                patrol = false;                
                enemy.stoppingDistance = 10f;
                enemy.SetDestination(player.transform.position);
                player = rayHit.collider.gameObject;                
            }
            if (!patrol && rayHit.collider.gameObject.tag != "Player")
            {
                Invoke("PatrolStart", 1f);
            }
            if (!fire&&rayHit.collider.gameObject.tag == "Player")
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
    void PatrolStart()
    {
        fire = false;
        enemy.stoppingDistance = 1f;
        patrol = true;
    }

    public void FixedUpdate()
    {        
        if (enemy.remainingDistance < enemy.stoppingDistance && patrol)
        {           
            enemy.SetDestination(patrolPoints[point].position);
            point++;
            if (point == patrolPoints.Count) point = 0;
        }
    }
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            drop=true;
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

