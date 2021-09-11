using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class idleReviewTextScript : MonoBehaviour
{
    public float offScreenLeft, offScreenRight, ReviewSpeed ,startingReviewSpeed;
    public bool isActive;
    public List<string> idleReviewTextQueue;
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        startingReviewSpeed = ReviewSpeed;
        this.transform.position = new Vector3(offScreenLeft, this.transform.position.y, this.transform.position.z);
        gameObject.GetComponent<TextMeshProUGUI>().text = idleReviewTextQueue[0];
    }

    // Update is called once per frame
    void Update()
    {
        moveText();


        if(idleReviewTextQueue.Count >= 10)
        {
            ReviewSpeed = 2 * Time.timeScale;
        }
        else
        {
            ReviewSpeed = startingReviewSpeed * Time.timeScale;
        }
    }

    void moveText()
    {
        this.transform.position = new Vector3(this.transform.position.x + ReviewSpeed , this.transform.position.y , this.transform.position.z);

        if (transform.position.x >= offScreenRight) 
        {
            transform.position = new Vector3(offScreenLeft, this.transform.position.y, this.transform.position.z);
                loadNewText();
        }
        
    }

    void loadNewText()
    {
        if(idleReviewTextQueue.Count > 0)
        {
            idleReviewTextQueue.RemoveAt(0);
            gameObject.GetComponent<TextMeshProUGUI>().text = idleReviewTextQueue[0];
        }
        else
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = "";
        }
        
    }

    public void queueIdleReview(string text) 
    {
        idleReviewTextQueue.Add(text);
    }
}
