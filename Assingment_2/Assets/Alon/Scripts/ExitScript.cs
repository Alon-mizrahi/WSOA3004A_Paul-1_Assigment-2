using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    CatSpawner Spawner;
    public int NumberOfGraduates =0;
    public GameManager GM;

    ExitDataCollection DataCollector;

    private void Start()
    {
        Spawner = GameObject.Find("CatSpawner").GetComponent<CatSpawner>();
        DataCollector = gameObject.GetComponentInChildren<ExitDataCollection>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cat")
        {
            //Debug.Log("COLLIDED: "+collision.gameObject.name);
            if (collision.gameObject.GetComponent<CatWander>().NeedFailed == true)
            {
                //might change destroy to just store somewhere else

                DataCollector.MoveCats(collision.gameObject);//pass cat to data collector

                //Destroy(collision.gameObject.GetComponent<CatObject>().UIHolder);
                //Destroy(collision.gameObject);

                Spawner.ReplaceCat();


            }
            else if (collision.gameObject.GetComponent<CatObject>().gradReady == true)
            {
                DataCollector.MoveCats(collision.gameObject);//pass cat to data collector

                //Destroy(collision.gameObject.GetComponent<CatObject>().UIHolder);
                //Destroy(collision.gameObject);

                NumberOfGraduates++;
                if (NumberOfGraduates == Spawner.NumberOfCatsToSpawn) { EndOfBatch(); }
            }
        }  
    }

    void EndOfBatch()
    {
        //NumberOfGraduates = 0;
        GM.EndOfBatch();
        //call function in game manager that pauses game between batches
    }
}
