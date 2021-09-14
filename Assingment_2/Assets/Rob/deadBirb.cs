using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadBirb : MonoBehaviour
{
    float deadbirb;
    // Start is called before the first frame update
    void Start()
    {
        deadbirb = 250;
    }

    // Update is called once per frame
    void Update()
    {
        deadbirb -= Time.deltaTime;

        if(deadbirb < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
