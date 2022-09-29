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
            Asteroid ast = PoolMgr.Instance.GetObj("GameObjects/Asteroid").gameObject.GetComponent<Asteroid>();
    
            ast.RandomSpawn(); //spawn the asteroid
            
            yield return new WaitForSeconds(spawnTime); //wait for few seconds to spawn next asteroid
        }
    }
}
