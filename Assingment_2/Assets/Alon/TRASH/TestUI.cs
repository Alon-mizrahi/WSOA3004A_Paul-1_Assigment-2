using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestUI : MonoBehaviour
{
    Canvas Canvas;
    public Image SpeechBubble;
    public Text Name;

    public Image NeedWater;
    public Image NeedWarmth;
    public Image NeedFood;
    public Image NeedPlay;

    public GameObject holder;

    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.Find("Canvas").GetComponent<Canvas>();

        SpeechBubble = gameObject.transform.Find("SpeechBubble_").GetComponent<Image>();
        Name = gameObject.transform.Find("Name_").GetComponent<Text>();

        NeedWater = SpeechBubble.transform.Find("Water").GetComponent<Image>();
        NeedWarmth = SpeechBubble.transform.Find("Warmth").GetComponent<Image>();
        NeedFood = SpeechBubble.transform.Find("Food").GetComponent<Image>();
        NeedPlay = SpeechBubble.transform.Find("Play").GetComponent<Image>();

        GameObject UIHolder = Instantiate(holder, gameObject.transform.position, Quaternion.identity);

        UIHolder.transform.SetParent(Canvas.transform);
        UIHolder.name = "Test_UI";

        SpeechBubble.transform.SetParent(UIHolder.transform);
        Name.transform.SetParent(UIHolder.transform);
        NeedWater.transform.SetParent(SpeechBubble.transform);
        NeedWarmth.transform.SetParent(SpeechBubble.transform);
        NeedFood.transform.SetParent(SpeechBubble.transform);
        NeedPlay.transform.SetParent(SpeechBubble.transform);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
