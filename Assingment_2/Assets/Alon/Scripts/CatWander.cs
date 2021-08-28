using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatWander : MonoBehaviour
{
    public Vector3 Target;
    BoxCollider2D Boundary;

    float UpperBound;
    float LowerBond;
    float LeftBound;
    float RightBound;
    bool Set = false;
    bool CanMove = false;
    public float speed=0.5f;

    CatObject CatScript;

    // Start is called before the first frame update
    void Start()
    {
        CatScript = gameObject.GetComponent<CatObject>();
        Boundary = GameObject.FindGameObjectWithTag("Boundary").GetComponent<BoxCollider2D>();
        UpperBound = Boundary.bounds.max.y;
        LowerBond = -Boundary.bounds.max.y;
        LeftBound = -Boundary.bounds.max.x;
        RightBound = Boundary.bounds.max.x;
        Target = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Target == gameObject.transform.position && Set == false)
        {
            Debug.Log("Setting new target");
            StartCoroutine("SetTarget");
        }
        else if(CanMove==true)
        {
            MoveTowards();
        }
    }

    IEnumerator SetTarget()
    {
        Set = true;
        yield return new WaitForSeconds(Random.Range(3,9)); //wait for some period
        //new target
        Target = new Vector3(Random.Range(LeftBound, RightBound), Random.Range(LowerBond, UpperBound), 0);

        if (gameObject.transform.position.x <= Target.x) //cat moving right
        {
            if (gameObject.transform.rotation.x != 180 || gameObject.transform.rotation.x != -180)
            {
                CatScript.NeedFood.transform.localPosition = new Vector3(0, 0, 0.01f);
                CatScript.NeedPlay.transform.localPosition = new Vector3(0, 0, 0.01f);
                CatScript.NeedWarmth.transform.localPosition = new Vector3(0, 0, 0.01f);
                CatScript.NeedWater.transform.localPosition = new Vector3(0, 0, 0.01f);
            
                gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
            }
            
        }
        else 
        {
            if (gameObject.transform.rotation.x != 0 || gameObject.transform.rotation.x != 360)
            {
                CatScript.NeedFood.transform.localPosition = new Vector3(0, 0, -0.01f);
            CatScript.NeedPlay.transform.localPosition = new Vector3(0, 0, -0.01f);
            CatScript.NeedWarmth.transform.localPosition = new Vector3(0, 0, -0.01f);
            CatScript.NeedWater.transform.localPosition = new Vector3(0, 0, -0.01f);

            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            }

                

        }

        Debug.Log("target SET");
        CanMove = true;
    }

    void MoveTowards()
    {
        //gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, Target, Time.time*0.1f);
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Target, Time.time*speed);
        if (gameObject.transform.position == Target) { Set = false; CanMove = false; }
    }


    private void OnMousedown()
    {
        Set = false;
        CanMove = false;
    }

    private void OnMouseUp()
    {
        Target = gameObject.transform.position;
    }


}
