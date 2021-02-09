using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour, ITakeDamage
{
    [SerializeField] private int hp = 2000;
    private NavMeshAgent enemy = null;
    [SerializeField] private float AtackSpeed = 0.25f;
    [SerializeField] private GameObject bullet = null;
    [SerializeField] private Transform bulletStartPosition = null;

    private GameObject player = null;
    private RaycastHit rayHit;
    private float sigthdist = 80f;
    private bool fire = false;
    private Animator _anibody;

    public void Awake()
    {
               
    }

    public void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        _anibody = gameObject.GetComponent<Animator>();
        _anibody.SetBool("Walk", true);
    }

    public void Update()
    {
        var rayVector = transform.position;
        rayVector.y += 2f;       
        if (Physics.Raycast(rayVector, player.transform.position - rayVector, out rayHit, sigthdist))
        {
            if (rayHit.collider.gameObject.tag == "Player")
            {
                enemy.stoppingDistance = 20f;
                enemy.transform.LookAt(player.transform);
                enemy.SetDestination(player.transform.position);                
                player = rayHit.collider.gameObject;
            }
            if (!fire && rayHit.collider.gameObject.tag == "Player")
            {
                fire = true;               
                StopAllCoroutines();
                StartCoroutine("StartFire");
            }           
        }
        if (fire)
        {
            _anibody.SetBool("Fire", true);
        }
        else
        {
            _anibody.SetBool("Fire", false);
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
        Destroy(gameObject);
    }
}
