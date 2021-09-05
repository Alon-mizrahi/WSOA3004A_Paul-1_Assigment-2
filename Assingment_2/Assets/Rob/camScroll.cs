using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camScroll : MonoBehaviour
{
    public GameObject camDolly;
    public float thres , clampX , clampY;
    public float camMoveSpeed;
    private float screenThres;
    // Start is called before the first frame update
    void Start()
    {
        screenThres = Screen.width / thres;
    }

    // Update is called once per frame
    void Update()
    {
        float adjustedCamMoveSpeedx = camMoveSpeed * (1 - (Mathf.Clamp(Input.mousePosition.x - Screen.width, 0 , camMoveSpeed)/camMoveSpeed)); // if inside the threshold , camera will move faster the closer it is the edge 
        float adjustedCamMoveSpeedy = camMoveSpeed * (1 - (Mathf.Clamp(Input.mousePosition.y - Screen.height, 0, camMoveSpeed) / camMoveSpeed));
      

        if (Input.mousePosition.x < screenThres) 
            camDolly.transform.position = new Vector3(camDolly.transform.position.x - adjustedCamMoveSpeedx, camDolly.transform.position.y , camDolly.transform.position.z);
        if (Input.mousePosition.x > Screen.width - screenThres)
            camDolly.transform.position = new Vector3(camDolly.transform.position.x + adjustedCamMoveSpeedx, camDolly.transform.position.y, camDolly.transform.position.z);

        if (Input.mousePosition.y < screenThres)
            camDolly.transform.position = new Vector3(camDolly.transform.position.x, camDolly.transform.position.y - adjustedCamMoveSpeedy, camDolly.transform.position.z);

        if (Input.mousePosition.y > Screen.height - screenThres)
            camDolly.transform.position = new Vector3(camDolly.transform.position.x, camDolly.transform.position.y + adjustedCamMoveSpeedy, camDolly.transform.position.z);


        camDolly.transform.position = new Vector3(Mathf.Clamp(camDolly.transform.position.x , -clampX , clampX ), Mathf.Clamp(camDolly.transform.position.y, -clampY, clampY), camDolly.transform.position.z);

    }
}
