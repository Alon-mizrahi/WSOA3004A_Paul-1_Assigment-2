using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Petting : MonoBehaviour
{
    CatObject CatScript;
    GameObject HeartUI;

    private void Start()
    {
        CatScript = gameObject.GetComponent<CatObject>();
        HeartUI = GameObject.Find("PettingHeart");
    }

    void OnMouseOver()
    {
        if (CatScript.CanPet == true && Input.GetMouseButton(1))//rightclick
        {
            Debug.Log("Petting " + gameObject.name);
            HeartUI.GetComponent<SpriteRenderer>().enabled = true;
            //CatScript.CanWander = false;

            //play purr
            //can show a heart UI
        }
        else
        {
            HeartUI.GetComponent<SpriteRenderer>().enabled = true;
            //CatScript.CanWander = true;
        }
    }

}
