using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cat")
        {
            Debug.Log("COLLIDED: "+collision.gameObject.name);
            if (collision.gameObject.GetComponent<CatWander>().NeedFailed == true)
            {
                Destroy(collision.gameObject.GetComponent<CatObject>().UIHolder);
                Destroy(collision.gameObject);
                    
            }
        }  
    }
}
