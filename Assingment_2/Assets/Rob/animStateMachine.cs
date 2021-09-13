using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animStateMachine : MonoBehaviour
{
    public Animator catAnim;
    public catGen catGen;
    public CatObject catObjScr;
    public bool isMoving, isMovePrev, isPickUp, isPickUpPrev;
    public int fatRoll;
    // Start is called before the first frame update
    void Start()
    {
        catGen = this.GetComponent<catGen>();
        catAnim = this.GetComponent<Animator>();
        catObjScr = this.GetComponentInParent<CatObject>();
        
    }

    // Update is called once per frame
    void Update()
    {
         isMoving = catObjScr.isMoving;
        isPickUp = catObjScr.isPickUp;

        if ((isMoving != isMovePrev) || (isPickUp != isPickUpPrev))
        {
            if(!isPickUp)
            {
                if (isMoving)
                {
                    if(!catGen.isFat)
                    {
                        catAnim.Play("catWalk2");
                    }
                    else
                    {
                        fatRoll = Random.Range(0, 100);
                        if (fatRoll < 50)
                        {
                            catAnim.Play("catFatWalk2");
                        }
                        else
                        {
                            catAnim.Play("catFatWalk");
                        }
                       
                    }
                   
                    //play movement anims
                }
                else
                {

                    if (!catGen.isFat)
                    {
                        catAnim.Play("catIdleAnim");
                    }
                    else
                    {
                        catAnim.Play("catFatIdleAnim");
                    }
                        
                    //play idle anims
                }
            }
            else
            {
                if(!catGen.isFat)
                {
                    catAnim.Play("catPickupStart");
                }
                else
                {
                    catAnim.Play("catFatPickupStart");
                }
               
                //play pickup anims
            }
           
            
           
        }

        isMovePrev = isMoving;
        isPickUpPrev = isPickUp;
    }





}
