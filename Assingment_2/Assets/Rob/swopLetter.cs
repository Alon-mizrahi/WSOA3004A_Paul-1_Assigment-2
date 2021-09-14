using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class swopLetter : MonoBehaviour
{
    public Sprite[] reviewSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void swapReview()
    {
        int sprite = Random.Range(0,3);
        this.GetComponent<Image>().sprite = reviewSprite[sprite];
    }
}
