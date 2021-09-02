using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatObject : MonoBehaviour
{

    //Cat properties
    public string Name;
    
    public string[] NeedList = {"Warmth", "Food", "Water", "Play" };  //list of needs of cats
    public string[] NameList = { "Juliette", "Alon", "Rob", "Milo", "Simba", "George", "Sam", "Boots", "Ziggy", "Vuk", "Pam" }; //list of names to choose
    //do a sprite array to randomly choose sprite
    public string CurrentNeed;                                                         

    //Cat Timing data
    public int Max_NeedTime =15;
    public int Min_NeedTime= 10;
    float NextNeedTime;

    public float NeedCountDownTimerMax = 15f;//how long a cats need can go unsatisfied
    public float NeedTimeLeft;

    //Cat Moods
    public bool hasNeed = false; //whether cat has a need or not
    public bool NeedSet = false;
    public bool isBusy = false; //use for when a cat is at a station. so not to assign a need or wander

    //Cat AI variables
    public bool CanWander = true; //can cat free roam
    //if cat at a station filling need, cant wander
    //if cat need unfifilled AI target is exit

    //cat leaving things
    CatWander WanderScript;
    public Transform Exit;
    bool Failed = false;

    //UI to display name and speech bubble for needs
    public Canvas Canvas;
    public Text Nametxt;

    SpriteRenderer SpeechBubble;
    public SpriteRenderer NeedWater;
    public SpriteRenderer NeedWarmth;
    public SpriteRenderer NeedFood;
    public SpriteRenderer NeedPlay;

    Image NeedTimer;

    public GameObject holder; //this is the prefab
    public GameObject UIHolder; //this is receranc to that object^
    CatUIFollow UIFollow;

    //cat Station Things
    public bool AtStation = false;
    public float StationCountDownTimerMax = 15f;//how long a cats need can go unsatisfied
    public float StationTimeLeft;
    public bool WasAtStation = false;

    // Start is called before the first frame update
    void Start()
    {
        NeedTimeLeft = NeedCountDownTimerMax;

        WanderScript = gameObject.GetComponent<CatWander>();
        Exit = GameObject.Find("Exit").GetComponent<Transform>();

        UIFollow = gameObject.GetComponentInChildren<CatUIFollow>();
        Name = GetName();
        SetUI();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (AtStation == false)
        { 
            if (hasNeed == false)
            {
                SetNeed();
            }
            else
            {
                NeedCountDown();
            }
        }else if (AtStation == true)
        {
            BeingSatisfied();
        }
        
    }

    //function that creates a need to occur in a time interval
    void SetNeed()
    {
        //check if no need
        //if need -> do nothing
        //if no need -> get time period to set new need
        //select random new need from array
        //select time period for need to start

            if (NeedSet == false)
            {
                NextNeedTime = Time.time + Random.Range(Min_NeedTime, Max_NeedTime);
                Debug.Log(Name+": Time till need "+ NextNeedTime);
                NeedSet = true;
            }

            if (NextNeedTime <= Time.time)
            {
                //Debug.Log("WE HERE");
                hasNeed = true;
                NeedSet = false;
                CurrentNeed = NeedList[Random.Range(0, NeedList.Length)];
                //Debug.Log("1"+CurrentNeed);
                SetUINeed(CurrentNeed);
                //NeedCountDown();
            }
    }

    void SetUINeed(string CurrentNeed)
    {
        Debug.Log(CurrentNeed);

        switch (CurrentNeed)
        {
            case "Warmth":
                SpeechBubble.enabled = true;
                NeedWater.enabled = false;
                NeedWarmth.enabled = true;
                NeedFood.enabled = false;
                NeedPlay.enabled = false;
                break;

            case "Food":
                SpeechBubble.enabled = true;
                NeedWater.enabled = false;
                NeedWarmth.enabled = false;
                NeedFood.enabled = true;
                NeedPlay.enabled = false;
                break;

            case "Water":
                SpeechBubble.enabled = true;
                NeedWater.enabled = true;
                NeedWarmth.enabled = false;
                NeedFood.enabled = false;
                NeedPlay.enabled = false;
                break;

            case "Play":
                SpeechBubble.enabled = true;
                NeedWater.enabled = false;
                NeedWarmth.enabled = false;
                NeedFood.enabled = false;
                NeedPlay.enabled = true;
                break;
        }

    }
    
    void NeedCountDown()
    {
        //NeedCountDownTimerMax
        //public float NeedTimeLeft;

        NeedTimer.enabled = true;
        NeedTimer.color = Color.red;
        if (NeedTimeLeft > 0)
        {
            NeedTimeLeft -= Time.deltaTime;
            NeedTimer.fillAmount = NeedTimeLeft / NeedCountDownTimerMax;
        }
        else //Need not met
        {
            //Wander target == to door,
            if (Failed == false)
            {
                CurrentNeed = "";
                Failed = true;
                WanderScript.NeedFail(Exit);
            }
            
        }
    }

    string GetName()
    {
        return NameList[Random.Range(0, NameList.Length)];
    }

    void SetUI()
    {
        gameObject.name = Name;

        Canvas = GameObject.Find("Canvas").GetComponent<Canvas>();

        NeedTimer = GameObject.Find("TimerUI").GetComponent<Image>();

        SpeechBubble = gameObject.transform.Find("CatSpeechBubble").GetComponent<SpriteRenderer>();
        Nametxt = gameObject.transform.Find("Name_").GetComponent<Text>();

        //SpeechBubble.name = "SpeechBubble_" + Name;
        Nametxt.name = "Name_"+ Name;

        NeedWater = SpeechBubble.transform.Find("CatNeedWater").GetComponent<SpriteRenderer>();
        NeedWarmth = SpeechBubble.transform.Find("CatNeedFire").GetComponent<SpriteRenderer>();
        NeedFood = SpeechBubble.transform.Find("CatNeedFood").GetComponent<SpriteRenderer>();
        NeedPlay = SpeechBubble.transform.Find("CatNeedPlay").GetComponent<SpriteRenderer>();

        UIHolder = Instantiate(holder, gameObject.transform.position, Quaternion.identity);

        UIHolder.transform.SetParent(Canvas.transform);
        UIHolder.name = "UI_" + Name;


        //SpeechBubble.transform.SetParent(UIHolder.transform);
        //SpeechBubble.transform.position = new Vector2(40, 20);

        Nametxt.text = Name;
        Nametxt.transform.SetParent(UIHolder.transform);
        Nametxt.transform.position = new Vector2(0, 0);

        //NeedWater.transform.SetParent(SpeechBubble.transform);
        //NeedWater.transform.position = SpeechBubble.transform.position;

        //NeedWarmth.transform.SetParent(SpeechBubble.transform);
        //NeedWarmth.transform.position = SpeechBubble.transform.position;

        //NeedFood.transform.SetParent(SpeechBubble.transform);
        //NeedFood.transform.position = SpeechBubble.transform.position;

        //NeedPlay.transform.SetParent(SpeechBubble.transform);
        //NeedPlay.transform.position = SpeechBubble.transform.position;

        NeedTimer.name = "Timer_" + Name;
        NeedTimer.transform.SetParent(UIHolder.transform);
        NeedTimer.transform.position = new Vector2(4.5f, 25);
        NeedTimer.enabled = false;

        SpeechBubble.enabled = false;
        NeedPlay.enabled = false;
        NeedFood.enabled = false;
        NeedWarmth.enabled = false;
        NeedWater.enabled = false;

        UIFollow.GetUI(UIHolder);
    }

    void BeingSatisfied()
    {
        //start station countdown
        //UI timer. change colour to blue

        NeedTimer.enabled = true;
        NeedTimer.color = Color.green;
        if (StationTimeLeft > 0)
        {
            StationTimeLeft -= Time.deltaTime;
            NeedTimer.fillAmount = StationTimeLeft / StationCountDownTimerMax;
        }
        else //Done at station
        {
            WasAtStation = true;
            CurrentNeed = "";
            CanWander = true;
            hasNeed = false;
            AtStation = false;
            gameObject.GetComponent<CatClickAndDrag>().CanDrag = true;
            ResetTimer();
            
            //turn off speechbuble and need
        }

    }

    public void ResetTimer()
    {
        StationTimeLeft = StationCountDownTimerMax;
        NeedTimeLeft = NeedCountDownTimerMax;
    }

    public void TurnOffSpeechBubble()
    {
        SpeechBubble.enabled = false;
        NeedWater.enabled = false;
        NeedWarmth.enabled = false;
        NeedFood.enabled = false;
        NeedPlay.enabled = false;
    }
}
