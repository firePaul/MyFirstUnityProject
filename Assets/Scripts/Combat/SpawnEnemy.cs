using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject Enemy = null;
    [SerializeField] private Transform Spawner = null;
    [SerializeField] private int SpawnTime = 30;

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
        Enem.name = $"Enemy#{rnd}";
    }
}
