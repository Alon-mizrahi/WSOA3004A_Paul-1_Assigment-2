using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatClickAndDrag : MonoBehaviour
{

    public float smoothSpeed = 0.125f;
    public bool CanDrag = true;

    CatObject CatScript;

    private void Start()
    {
        CatScript = gameObject.GetComponent<CatObject>();
    }

    private void OnMouseDrag()
    {
        if (CanDrag == true && gameObject.GetComponent<CatClickAndDrag>().enabled == true)
        {
            CatScript.isPickUp = true;
            CatScript.isMoving = false;

            CatScript.Nametxt.enabled = true;
            CatScript.hearts.enabled = true;

            Vector2 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 desiredPosition = mouseposition;
            Vector2 smoothedPosition = Vector2.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = new Vector3 (smoothedPosition.x , smoothedPosition.y, gameObject.transform.position.z); 
        }
    }

    private void OnMouseUp()
    {
        CatScript.isPickUp = false;
        CatScript.Nametxt.enabled = false;
        CatScript.hearts.enabled = false;
    }


}
