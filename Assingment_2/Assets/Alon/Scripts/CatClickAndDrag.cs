using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatClickAndDrag : MonoBehaviour
{

    public float smoothSpeed = 0.125f;
    

    private void OnMouseDrag()
    {
        Vector2 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 desiredPosition = mouseposition;
        Vector2 smoothedPosition = Vector2.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

    }

}
