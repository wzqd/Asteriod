using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : SingletonMono<AsteroidSpawner>
{

    private float asteroidSpawnTime = 2;
    private float nukeSpawnTime = 10;
    void Start()
    {
        //events for asteroid spawning
        EventMgr.Instance.AddEventListener("StartGame", (() =>
        {
            TimeMgr.Instance.StartTimer(2, (() =>
            {
                StartCoroutine("AsteroidSpawnCoroutine");
            }));
        }));
        
        EventMgr.Instance.AddEventListener("GameOver", (() =>
        {
            StopCoroutine("AsteroidSpawnCoroutine");
        }));
        EventMgr.Instance.AddEventListener("RestartGame", () =>
        {
            StartCoroutine("AsteroidSpawnCoroutine");
        });        
        
        //events for nuke spawning
        EventMgr.Instance.AddEventListener("StartGame", (() =>
        {            
            TimeMgr.Instance.StartTimer(5, (() =>
            {
                StartCoroutine("NukeSpawnCoroutine");
            }));
        }));
        
        EventMgr.Instance.AddEventListener("GameOver", (() =>
        {
            StopCoroutine("NukeSpawnCoroutine");
        }));
        EventMgr.Instance.AddEventListener("RestartGame", () =>
        {
            StartCoroutine("NukeSpawnCoroutine");
        });
        
        


    }

    private IEnumerator AsteroidSpawnCoroutine() //coroutine method
    {
        while (true)
        {
            Asteroid ast = PoolMgr.Instance.GetObj("GameObjects/Asteroid").gameObject.GetComponent<Asteroid>();
    
            ast.RandomSpawn(); //spawn the asteroid
            
            yield return new WaitForSeconds(asteroidSpawnTime); //wait for few seconds to spawn next asteroid
        }
    }    
    
    private IEnumerator NukeSpawnCoroutine() //coroutine method
    {
        while (true)
        {
            Nuke nuke = PoolMgr.Instance.GetObj("GameObjects/Nuke").gameObject.GetComponent<Nuke>();
    
            nuke.RandomSpawn(); //spawn the asteroid
            
            yield return new WaitForSeconds(nukeSpawnTime); //wait for few seconds to spawn next asteroid
        }
    }
}
