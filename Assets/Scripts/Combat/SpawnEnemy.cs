using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject Enemy = null;
    [SerializeField] private Transform Spawner = null;
    [SerializeField] private int SpawnTime = 60;
    [SerializeField] private GameObject Waypoints = null;
    private List<int> points;
    private List<Transform> waypoints;

    void Start()
    {
        StartCoroutine("DoSpawn");
    }
    IEnumerator DoSpawn()
    {
        for(; ; )
        {
            Spawn();           
            yield return new WaitForSeconds(SpawnTime);
        }
    }   
    void Spawn()
    {        
        var Enem = Instantiate(Enemy, Spawner.position, Quaternion.identity);
        var rnd = Random.Range(0, 1000);
        var numberofpoints = Random.Range(2, Waypoints.transform.childCount);
        points = new List<int>();
        for (int i = 0; i < numberofpoints;)
        {
            var randompoint = Random.Range(0, Waypoints.transform.childCount);
            if (!points.Contains(randompoint))
            {
                points.Add(randompoint); i++;
            }
        }
        waypoints = new List<Transform>();
        for (int i = 0; i < numberofpoints; i++)
        {
            waypoints.Add(Waypoints.transform.GetChild(points[i]));
        }                  
        Enem.name = $"Enemy#{rnd}";
        Enem.GetComponent<IPatrol>().SetPatrolPoints(waypoints);       
    }
}
