using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    CatSpawner Spawner;
    int NumberOfGraduates;

    private void Start()
    {
        Spawner = GameObject.Find("CatSpawner").GetComponent<CatSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cat")
        {
            //Debug.Log("COLLIDED: "+collision.gameObject.name);
            if (collision.gameObject.GetComponent<CatWander>().NeedFailed == true)
            {
                //might change destroy to just store somewhere else
                Destroy(collision.gameObject.GetComponent<CatObject>().UIHolder);
                Destroy(collision.gameObject);

                Spawner.ReplaceCat();

            }
            else if (collision.gameObject.GetComponent<CatObject>().gradReady == true)
            {
                NumberOfGraduates++;
                if (NumberOfGraduates >= Spawner.NumberOfCatsToSpawn) { EndOfBatch(); }
            }
        }  
    }

    void EndOfBatch()
    {
        NumberOfGraduates = 0;
        //call function in game manager that pauses game between batches
    }
}
