using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    CatSpawner Spawner;
    public Image AfterBatch;
    public ExitDataCollection DataCollector;


    //testing
    public Text speedTxt;


    // Start is called before the first frame update
    void Start()
    {
        Spawner = GameObject.Find("CatSpawner").GetComponent<CatSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }
    }


    public void EndOfBatch()
    {
        //at end of batch activate overlay
        // can read reviews,
        //game paused
        // button to go to nexed batch
        AfterBatch.gameObject.SetActive(true);
        DataCollector.GetCatData();

    }

    public void NexDay()//on Button Press
    {
        Spawner.StartOfBatch = true;
        AfterBatch.gameObject.SetActive(false);
        DataCollector.ClearRoundData();
    }


    public void TestingSpeed()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 2;
            speedTxt.text = "Speed: 2X";
        }
        else if (Time.timeScale == 2)
        {
            Time.timeScale = 3;
            speedTxt.text = "Speed: 3X";
        }
        else if (Time.timeScale == 3)
        {
            Time.timeScale = 1;
            speedTxt.text = "Speed: 1X";
        }
    }



}
