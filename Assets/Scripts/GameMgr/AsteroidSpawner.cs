using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    private float spawnTime = 2;
    void Start()
    {
        StartCoroutine("SpawnCoroutine");
    }
    
    void Update()
    {
        
    }

    private IEnumerator SpawnCoroutine() //coroutine method
    {
        while (true)
        {
            PoolMgr.Instance.GetObj("GameObjects/Asteroid");

            yield return new WaitForSeconds(spawnTime); //wait for few seconds to spawn next asteroid
        }
    }
}
