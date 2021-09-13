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
    public bool Set = false;
    public bool CanMove = false;
    public float speed=0.5f;

    CatObject CatScript;

    public bool NeedFailed = false;
    bool Clicked = false;

    Transform ExitPos;

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
        if (CatScript.CanWander == true) {
            if (Target == gameObject.transform.position && Set == false)
            {
                CatScript.isMoving = false;
                Debug.Log("Setting new target");
                StartCoroutine("SetTarget");
            }
            else if (CanMove == true)
            {
                if (Clicked == false) { CatScript.isMoving = true; }
                MoveTowards();
            }
            else if (NeedFailed == true)
            {
                if (Clicked == false)
                {
                    CatScript.isMoving = true;
                }
                //Debug.Log("MOVING TOWARDS EXIT");
                MoveExit();
            }
            else if (CatScript.gradReady==true)
            {
                GraduateMoveToExit();
            }
        }
    }

    IEnumerator SetTarget()
    {
        Set = true;
        if (NeedFailed == false)
        {
            yield return new WaitForSeconds(Random.Range(3, 9)); //wait for some period
            //new target
            Target = new Vector3(Random.Range(LeftBound, RightBound), Random.Range(LowerBond, UpperBound), gameObject.transform.position.z);

            if (gameObject.transform.position.x <= Target.x) //cat moving right
            {
                if (gameObject.transform.rotation.x != 180 || gameObject.transform.rotation.x != -180)
                {
                    CatScript.SpeechBubble.transform.localPosition = new Vector3(-2.12f, 1.26f, 1f);
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
                    CatScript.SpeechBubble.transform.localPosition = new Vector3(-2.12f, 1.26f, -1f);
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
        else { CanMove = false; }
    }

    void MoveTowards()
    {
        if (NeedFailed == false)
        {
            //CatScript.isMoving = true;
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Target, Time.deltaTime * speed);
            if (gameObject.transform.position == Target) { Set = false; CanMove = false; }
        }
        else
        {
            CanMove = false;
            //CatScript.isMoving = true;
        }
    }


    private void OnMousedown()
    {
        Clicked = true;
        CatScript.isMoving = false;

        if (NeedFailed == false)
        {
            Set = false;
            CanMove = false;
        }
        
    }

    private void OnMouseUp()
    {
        Clicked = false;
        if (NeedFailed == false)
        {
            Target = gameObject.transform.position;
        }      
    }



    public void NeedFail(Transform Exit)
    {
        Set = true;
        NeedFailed = true;
        CanMove = false;
        Debug.Log("NEED FAILED");

        speed = speed*1.6f;
        //Target = Exit.position;
        Target = new Vector3(Exit.position.x, Exit.position.y, gameObject.transform.position.z);
        ExitPos = Exit;

        gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
    }

    void MoveExit()
    {
        Set = true;
        NeedFailed = true;
        CanMove = false;
        gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
        //Target = ExitPos.position;
        Target = new Vector3(ExitPos.position.x, ExitPos.position.y, gameObject.transform.position.z);
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Target, Time.deltaTime * speed);
    }

    public void GradMove(Transform Exit)
    {
        Set = true;
        NeedFailed = false;
        CanMove = false;
        
        speed = speed * 1.6f;
        //Target = Exit.position;
        Target = new Vector3(ExitPos.position.x, ExitPos.position.y, gameObject.transform.position.z);
        ExitPos = Exit;

        gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
    }


    void GraduateMoveToExit()
    {
        Set = true;
        NeedFailed = false;
        CanMove = false;
        gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
        Target = new Vector3(ExitPos.position.x , ExitPos.position.y, gameObject.transform.position.z);
            
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Target, Time.deltaTime * speed);
    }
}
