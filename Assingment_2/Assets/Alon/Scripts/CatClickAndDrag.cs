using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatClickAndDrag : MonoBehaviour
{

    public float smoothSpeed = 0.125f;

    public LayerMask DraggableMask;



    private void OnMouseDrag()
    {

        Vector2 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 desiredPosition = mouseposition;
        Vector2 smoothedPosition = Vector2.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;   
    }


    /*
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, DraggableMask);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
            }

        }
    }
    */
}
