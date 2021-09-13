using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpawner : MonoBehaviour
{
    public GameObject Cat;  //cat prefab
    public int Min_SpawnTime = 10;
    public int Max_SpawnTime = 20;
    bool HaveSpawn = false;
    float NextSpawnTime;

    GameObject SpawnedCat;

    //public GameObject[] CurrentCats;

    public int BatchNumber = 1;
    public bool StartOfBatch = true;
    public float NumberOfCatsToSpawn;


    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(Cat, gameObject.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        //Spawner();
        if (StartOfBatch == true)
        {
            StartOfBatch = false;
            BatchSpawner();
        }
    }


    void BatchSpawner()
    {
        //NumberOfCatsToSpawn = 3 * BatchNumber; //3, 6, 9, 12 ... fine for now, can do a different intervals if time
        //Debug.Log("NumberOfCatsToSpawn: "+ NumberOfCatsToSpawn);
        SinusoidalSpawner(); //if use comment out above line

        for (int i = 0; i < NumberOfCatsToSpawn; i++)
        {
            SpawnedCat = Instantiate(Cat, gameObject.transform.position, Quaternion.identity);


            SpawnedCat.transform.position = new Vector3(SpawnedCat.transform.position.x, SpawnedCat.transform.position.y, transform.position.z-i);


        }
        BatchNumber++;
    }

    public void ReplaceCat()
    {
        Instantiate(Cat, gameObject.transform.position, Quaternion.identity);
    }



    void SinusoidalSpawner()
    {
        if (BatchNumber > 10) { BatchNumber = 5; }


        float angle = 2 + Mathf.Abs(1*BatchNumber * Mathf.Sin(2*BatchNumber));//needs adjusting

        NumberOfCatsToSpawn = Mathf.Round(angle);

        Debug.Log("SIN Val: "+ angle);
        Debug.Log("Spawning: " + NumberOfCatsToSpawn);
    }









     /*

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
            CatCount();//count current cats to change values
        }
    }


    void CatCount()
    {
        CurrentCats = GameObject.FindGameObjectsWithTag("Cat");
        //CurrentCats.Length


        if (CurrentCats.Length <= 3)
        {
            Min_SpawnTime = 10;
            Max_SpawnTime = 20;
        }
        else if (CurrentCats.Length <= 5)
        {
            Min_SpawnTime = 15;
            Max_SpawnTime = 25;
        }
        else if (CurrentCats.Length <= 7)
        {
            Min_SpawnTime = 20;
            Max_SpawnTime = 30;
        }
        else if (CurrentCats.Length <= 10)
        {
            Min_SpawnTime = 30;
            Max_SpawnTime = 40;
        }
        else if (CurrentCats.Length > 10)
        {
            Min_SpawnTime = 50;
            Max_SpawnTime = 60;
        }
    }
    */

}


        
        
        
        
        