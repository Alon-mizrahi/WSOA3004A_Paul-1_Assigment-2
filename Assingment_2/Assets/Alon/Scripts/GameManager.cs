using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    CatSpawner Spawner;
    public Image AfterBatch;
    public ExitDataCollection DataCollector;
    public TextMeshProUGUI tempReviewText;



    //testing
    public Text speedTxt;
    public float fiveStarTime , fourStarTime , threeStarTime , twoStarTime , oneStarTime;


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
        tempReviewText.text = DataCollector.catEndReviews[0];

    }

    public void NexDay()//on Button Press
    {
        Spawner.StartOfBatch = true;
        AfterBatch.gameObject.SetActive(false);
        DataCollector.ClearRoundData();
    }

    public void NextReview()
    {
        if(DataCollector.catEndReviews.Count != 0)
        {
            DataCollector.catEndReviews.RemoveAt(0);
            tempReviewText.text = DataCollector.catEndReviews[0];

        }
        else
        {
            NexDay();
        }
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

    public int calculateStarValue(float gradTime ,bool grad , int maxHearts , int heartsLost)
    {
        if(grad)
        {

            if (gradTime <= fiveStarTime) return 5;

            if (gradTime > fiveStarTime && gradTime < fourStarTime) return 4;

            if (gradTime > fourStarTime && gradTime < threeStarTime) return 3;

            if (gradTime > threeStarTime && gradTime < twoStarTime) return 2;

            if (gradTime > twoStarTime) return 1;

            return 1;
        }
        else
        {
            return 0;
        }
    }



}
