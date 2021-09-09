using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    CatSpawner Spawner;
    public Image AfterBatch;


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


    }

    public void NexDay()//on Button Press
    {

    }





}
