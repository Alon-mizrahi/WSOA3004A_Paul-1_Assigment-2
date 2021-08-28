using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatUIFollow : MonoBehaviour
{

    //public Text NameLabel; //Name text
    //public Image NeedBubble;
    //needs bubble can have children in it
    public GameObject UIHolder;


    CatObject Cat;

    bool foundUI = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Cat = gameObject.GetComponent<CatObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (foundUI == true)
        {
            Vector3 namePos = Camera.main.WorldToScreenPoint(this.transform.position);
            //NameLabel.transform.position = namePos;
            //NeedBubble.transform.position = namePos;
            UIHolder.transform.position = namePos;
        }        
    }

    public void GetUI(GameObject UI)
    {
        //Debug.Log("This is not the problem");
        //NameLabel = Cat.Nametxt;
        //NeedBubble = Cat.SpeechBubble;
        UIHolder = UI;
        foundUI = true;
    }

}
