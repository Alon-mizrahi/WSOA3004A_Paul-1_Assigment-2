using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewStationScript : MonoBehaviour
{
    public int MaxNumberOfCats = 5;

    public int CatCount = 0;

    public string StationNeed;

    // Start is called before the first frame update
    void Start()
    {
        FindNeed();
    }

    void FindNeed()
    {
        switch (gameObject.name)
        {
            case "Station_Water":
                StationNeed = "Water";
                break;

            case "Station_Fire":
                StationNeed = "Warmth";
                break;

            case "Station_Food":
                StationNeed = "Food";
                break;

            case "Station_Play":
                StationNeed = "Play";
                break;
        }

    }


    //cat walks into station, check if cat need matches station. check if station full.
    // if right station and not full, add cat to station. start timer and stop cat drag, wondering
    //else do notheing


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
