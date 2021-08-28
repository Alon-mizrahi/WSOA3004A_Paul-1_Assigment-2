using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationScript : MonoBehaviour
{
    public int MaxNumberOfCats=5;

    public int CatCount = 0;

    public string StationNeed;

    // Start is called before the first frame update
    void Start()
    {
        FindNeed();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cat" && CatCount < MaxNumberOfCats && StationNeed == collision.gameObject.GetComponent<CatObject>().CurrentNeed)
        {
            Debug.Log(collision.gameObject.name);

            CatCount++;
            collision.gameObject.GetComponent<CatObject>().AtStation = true;
            collision.gameObject.GetComponent<CatObject>().ResetTimer();
            collision.gameObject.GetComponent<CatObject>().CanWander = false;
            collision.gameObject.GetComponent<CatObject>().TurnOffSpeechBubble();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cat" && collision.gameObject.GetComponent<CatObject>().WasAtStation == true)
        {
            Debug.Log(collision.gameObject.name);
            collision.gameObject.GetComponent<CatObject>().WasAtStation = false;
            CatCount--;
            //collision.gameObject.GetComponent<CatObject>().ResetTimer();
            //collision.gameObject.GetComponent<CatObject>().CanWander = true;
            //collision.gameObject.GetComponent<CatObject>().AtStation = false;
        }
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
