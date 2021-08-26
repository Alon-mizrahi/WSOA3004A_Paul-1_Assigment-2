using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatObject : MonoBehaviour
{

    //Cat properties
    public string Name;
    
    public string[] NeedList = {"Warmth", "Food", "Water", "Play" };  //list of needs of cats
    public string[] NameList = { "Juliette", "Alon", "Rob", "Milo", "Simba", "George", "Sam", "Boots", "Ziggy", "Vuk" }; //list of names to choose
    public string CurrentNeed;                                                                                                        //do a sprite array to randomly choose sprite

    //Cat Timing data
    public float Max_NeedTime =15f;
    public float Min_NeedTime= 10f;
    float NextNeedTime;

    //Cat Moods
    public bool hasNeed = false; //whether cat has a need or not
    bool NeedSet = false;
    public bool isBusy = false; //use for when a cat is at a station. so not to assign a need or wander

    //Cat AI variables
    //bool CanWander = true; //can cat free roam
    //if cat at a station filling need, cant wander
    //if cat need unfifilled AI target is exit



    //UI to display name and speech bubble for needs
    public Canvas Canvas;
    public Image SpeechBubble;
    public Text Nametxt;

    public Image NeedWater;
    public Image NeedWarmth;
    public Image NeedFood;
    public Image NeedPlay;

    public GameObject holder;
    public GameObject UIHolder;
    CatUIFollow UIFollow;


    // Start is called before the first frame update
    void Start()
    {
        UIFollow = gameObject.GetComponentInChildren<CatUIFollow>();
        Name = GetName();
        SetUI();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (NeedSet == false)
        {
            //SetNeed();
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

        if (hasNeed == false) //needs a new need
        {
            if (NeedSet == false)
            {
                NextNeedTime = Time.time + Random.Range(Min_NeedTime, Max_NeedTime);
                Debug.Log(NextNeedTime);
                NeedSet = true;
            }

            if (NextNeedTime <= Time.time)
            {
                hasNeed = true;
                NeedSet = false;
                CurrentNeed = NeedList[Random.Range(0, NeedList.Length)];
                Debug.Log(CurrentNeed);
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

        SpeechBubble = gameObject.transform.Find("SpeechBubble_").GetComponent<Image>();
        Nametxt = gameObject.transform.Find("Name_").GetComponent<Text>();

        SpeechBubble.name = "SpeechBubble_" + Name;
        Nametxt.name = "Name_"+ Name;

        NeedWater = SpeechBubble.transform.Find("Water").GetComponent<Image>();
        NeedWarmth = SpeechBubble.transform.Find("Warmth").GetComponent<Image>();
        NeedFood = SpeechBubble.transform.Find("Food").GetComponent<Image>();
        NeedPlay = SpeechBubble.transform.Find("Play").GetComponent<Image>();

        UIHolder = Instantiate(holder, gameObject.transform.position, Quaternion.identity);

        UIHolder.transform.SetParent(Canvas.transform);
        UIHolder.name = "UI_" + Name;

        SpeechBubble.transform.SetParent(UIHolder.transform);
        SpeechBubble.transform.position = Vector3.zero;

        Nametxt.text = Name;
        Nametxt.transform.SetParent(UIHolder.transform);
        Nametxt.transform.position = Vector3.zero;

        NeedWater.transform.SetParent(SpeechBubble.transform);
        NeedWater.transform.position = Vector3.zero;

        NeedWarmth.transform.SetParent(SpeechBubble.transform);
        NeedWarmth.transform.position = Vector3.zero;

        NeedFood.transform.SetParent(SpeechBubble.transform);
        NeedFood.transform.position = Vector3.zero;

        NeedPlay.transform.SetParent(SpeechBubble.transform);
        NeedPlay.transform.position = Vector3.zero;

        SpeechBubble.enabled = false;
        NeedPlay.enabled = false;
        NeedFood.enabled = false;
        NeedWarmth.enabled = false;
        NeedWater.enabled = false;

        UIFollow.GetUI(UIHolder);
    }



}
