using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    CatSpawner Spawner;
    public GameObject AfterBatch;
    public ExitDataCollection DataCollector;
    public TextMeshProUGUI tempReviewText;

    public Image UntilFinishUI;
    public ExitScript Exit;

    //testing
    public Text speedTxt;
    public float fiveStarTime , fourStarTime , threeStarTime , twoStarTime , oneStarTime;
    public Animator reviewAnim;


    // Start is called before the first frame update
    void Start()
    {
        Spawner = GameObject.Find("CatSpawner").GetComponent<CatSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }
        UntilBatchComplete();
    }


    public void EndOfBatch()
    {
        //at end of batch activate overlay
        // can read reviews,
        //game paused
        // button to go to nexed batch
        Exit.NumberOfGraduates = 0;
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
            if( DataCollector.catEndReviews.Count != 0)  //@Rob took this out cos was being wierd
            {
                reviewAnim.Play("ReviewAnim");
                tempReviewText.text = DataCollector.catEndReviews[0];
            }
            

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
            if (gradTime <= fiveStarTime) return 0;

            if (gradTime > fiveStarTime && gradTime < threeStarTime) return 1;

            if (gradTime > threeStarTime && gradTime < twoStarTime) return 2;

            if (gradTime > twoStarTime) return 3;

            return 0;
        }
    }


    void UntilBatchComplete()
    {
        UntilFinishUI.fillAmount = Exit.NumberOfGraduates / Spawner.NumberOfCatsToSpawn;
    }





}
