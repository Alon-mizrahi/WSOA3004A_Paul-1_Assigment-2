using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatNavMesh : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float rotSpeed = 100f;

    private bool isWander = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;


    // Start is called before the first frame update
    void Start()
    {
        //gameObject.GetComponent<CapsuleCollider>().bounds.m
    }

    // Update is called once per frame
    void Update()
    {
        if (isWander == false)
        {
            StartCoroutine("Wander");
        }

        if (isRotatingRight == true)
        {
            transform.Rotate(transform.forward * Time.deltaTime*rotSpeed);
        }
        if (isRotatingLeft == true)
        {
            transform.Rotate(transform.forward * Time.deltaTime * -rotSpeed);
        }
        if (isWalking == true)
        {
            transform.position += transform.up * moveSpeed * Time.deltaTime;
        }


    }

    IEnumerator Wander()
    {
        int RotTime = Random.Range(1, 3);
        int RotateWait = Random.Range(2, 5); //time between rotating
        int RotateLorR = Random.Range(0, 3);
        int WalkWait = Random.Range(3, 7); //time between walking
        int WalkTime = Random.Range(1, 5);

        isWander = true;

        yield return new WaitForSeconds(WalkWait);

        isWalking = true;
        yield return new WaitForSeconds(WalkTime);
        isWalking = false;

        yield return new WaitForSeconds(RotateWait);

        if (RotateLorR == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(RotTime);
            isRotatingRight = false;
        }

        if (RotateLorR == 2)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(RotTime);
            isRotatingLeft = false;
        }

        isWander = false;

    }

}
