using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour, ITakeDamage, IPatrol
{
    [SerializeField] private int hp = 100;
    [SerializeField] private NavMeshAgent enemy=null;
    private List<Transform> patrolPoints = new List<Transform>();
    private int point=0;


    public void SetPatrolPoints(List<Transform> points)
    {
        foreach (Transform point in points)
        {
            patrolPoints.Add(point);
        }      
    }

    public void FixedUpdate()
    {        
        if (enemy.remainingDistance < enemy.stoppingDistance)
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
            Death();
        }
    }
    private void Death()
    {
        Destroy(gameObject, 0);
    }
}

