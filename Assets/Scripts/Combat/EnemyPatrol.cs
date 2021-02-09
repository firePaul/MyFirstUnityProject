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
    private Animator _Enemy;

    private List<Transform> patrolPoints = new List<Transform>();
    
    private GameObject player = null;
    private int point=0;
    private bool drop = false;
    private RaycastHit rayHit;
    private float sigthdist = 40f;
    private bool patrol=false;
    private bool fire = false;

    public void Awake()
    {
        droppoint = gameObject.transform.GetChild(0);
        enemy = GetComponent<NavMeshAgent>();
        _Enemy = gameObject.GetComponent<Animator>();
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
        var rayVector = transform.position;
        rayVector.y += 2f;
        if (Physics.Raycast(rayVector, player.transform.position - rayVector, out rayHit, sigthdist))
        {
            //Debug.DrawRay(rayVector, player.transform.position - rayVector, Color.red);
            if (rayHit.collider.gameObject.tag == "Player")
            {
                patrol = false;                
                enemy.stoppingDistance = 20f;
                enemy.transform.LookAt(player.transform);
                enemy.SetDestination(player.transform.position);
                player = rayHit.collider.gameObject;
                //Debug.DrawRay(rayVector, player.transform.position - rayVector, Color.green);
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
        enemy.stoppingDistance = 5f;
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
        if (enemy.isOnOffMeshLink && !_Enemy.GetBool("Jump"))
        {
            _Enemy.SetBool("Jump", true);
        }
        if (!enemy.isOnOffMeshLink&& _Enemy.GetBool("Jump"))
        {
            _Enemy.SetBool("Jump", false);
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

