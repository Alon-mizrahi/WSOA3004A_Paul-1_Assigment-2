using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatWander : MonoBehaviour
{

    Transform Target;
    CatObject CatScript;
    GameObject Floor;
    float RoomBoundX;
    float RoomBoundZ;
    bool TargetSet = false;
    public float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.Find("Target").GetComponent<Transform>();
        CatScript = gameObject.GetComponent<CatObject>();
        Floor = GameObject.FindWithTag("Floor");
        RoomBoundX = Floor.GetComponent<BoxCollider>().bounds.max.x;
        RoomBoundZ = Floor.GetComponent<BoxCollider>().bounds.max.z;
        Target.parent = null;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)) { Target.position = new Vector3(Random.Range(-RoomBoundX+1, RoomBoundX-1), gameObject.transform.position.y ,Random.Range(-RoomBoundZ+1, RoomBoundZ-1)); }


        if (CatScript.CanWander == true)
        {
            if (gameObject.transform != Target)
            {

                if (TargetSet == false)
                {
                    Target.position = new Vector2(Random.Range(-RoomBoundX, RoomBoundX), Random.Range(-RoomBoundZ, RoomBoundZ));
                    TargetSet = true;
                }

                gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, Target.position, speed * Time.deltaTime);

            }
            else
            {
                Target.position = new Vector2(Random.Range(-RoomBoundX, RoomBoundX), Random.Range(-RoomBoundZ, RoomBoundZ));
            }
        }
        
    }


}
