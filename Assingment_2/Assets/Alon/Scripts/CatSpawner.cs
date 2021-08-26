using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpawner : MonoBehaviour
{
    public GameObject Cat;  //cat prefab
    public float Min_SpawnTime = 30f;
    public float Max_SpawnTime = 40f;
    bool HaveSpawn = false;
    float NextSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Spawner();
    }

    void Spawner()
    {
        if (HaveSpawn == false)
        {
            NextSpawnTime = Time.time + Random.Range(Min_SpawnTime, Max_SpawnTime);
            Debug.Log(NextSpawnTime);
            HaveSpawn = true;
        }

        if (NextSpawnTime <= Time.time)
        {
            HaveSpawn = false;
            Instantiate(Cat, gameObject.transform.position, Quaternion.identity);
        }
    }


}
