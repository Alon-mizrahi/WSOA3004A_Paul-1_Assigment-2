using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewStationScript : MonoBehaviour
{
    public int MaxNumberOfCats = 5;

    //public int CatCount = 0;

    public string StationNeed;

    public GameObject[] CurrentCats;
    public bool ArrFull = false;

    // Start is called before the first frame update
    void Start()
    {
        CurrentCats = new GameObject[MaxNumberOfCats];

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

    private void Update()
    {
        CheckArray();
    }

    //cat walks into station, check if cat need matches station. check if station full.
    // if right station and not full, add cat to station. start timer and stop cat drag, wondering
    //else do notheing


    private void OnTriggerEnter2D(Collider2D other)
    {
        //CheckArray();
        if (other.gameObject.tag == "Cat" && StationNeed == other.gameObject.GetComponent<CatObject>().CurrentNeed && ArrFull == false && other.gameObject.GetComponent<CatObject>().CurrentNeed != "")
        {
            //add to array
            AddToArray(other.gameObject);
            //cat things
            Debug.Log("GOT IN!!");

            other.gameObject.GetComponent<CatObject>().AtStation = true;
            other.gameObject.GetComponent<CatObject>().ResetTimer();
            other.gameObject.GetComponent<CatObject>().CanWander = false;
            other.gameObject.GetComponent<CatClickAndDrag>().CanDrag = false;
            other.gameObject.GetComponent<CatObject>().TurnOffSpeechBubble();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (WasAtStation(other.gameObject))
        {
            RemoveFromArray(other.gameObject);
        }
    }


    void AddToArray(GameObject Cat)
    {
        Debug.Log("TryingToAddTo: " + gameObject.name);
        for (int i = 0; i < CurrentCats.Length; i++)
        {
            if (CurrentCats[i] == null)
            {
                CurrentCats[i] = Cat;
                break;
            }
        }
    }

    bool WasAtStation(GameObject Cat)
    {
        for (int i = 0; i < CurrentCats.Length; i++)
        {
            if (CurrentCats[i] == Cat)
            {
                return true;
            }
        }
        return false;
    }

    void RemoveFromArray(GameObject Cat)
    {
        for (int i = 0; i < CurrentCats.Length; i++)
        {
            if (CurrentCats[i] == Cat)
            {
                CurrentCats[i] = null;
                break;
            }
        }
    }

    void CheckArray()
    {
        for (int i = 0; i < CurrentCats.Length; i++)
        {
            if (CurrentCats[i] == null)
            {
                ArrFull = false;
                break;
            }else
            {
                ArrFull = true;
            }
        }

    }
}
