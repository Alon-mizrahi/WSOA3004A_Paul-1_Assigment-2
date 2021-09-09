using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDataCollection : MonoBehaviour
{
    //public string[] Names;
    //public bool[] DidGrad;
    //public float[] GradTime;
    //public int[] HeartCount;

    public int index = 0;

    public CatObject[] CatList;
    public int TotalCats;

    /*
    public void StartOfBatch()
    {
        
        StartCats = GameObject.FindGameObjectsWithTag("Cat");
        TotalCats = StartCats.Length;

        Names = new string[TotalCats];
        DidGrad = new bool[TotalCats];
        GradTime = new float[TotalCats];
        HeartCount = new int[TotalCats];
        Debug.Log("CALLED THIS");
    }
    */

    public void MoveCats(GameObject Cat)
    {
        Cat.transform.SetParent(gameObject.transform);

        Cat.transform.localPosition = new Vector3(0, 0, 0);

        Cat.GetComponent<CatWander>().enabled = false;
        Cat.GetComponent<CatClickAndDrag>().enabled = false;
        Cat.GetComponent<Petting>().enabled = false;
        Cat.GetComponent<CatObject>().enabled = false;//?? can we still access data?

    }



    public void GetCatData(GameObject Cat)
    {
        TotalCats = transform.childCount;
        CatList = new CatObject[TotalCats];

        CatList = GetComponentsInChildren<CatObject>();



        for (index = 0; index < TotalCats; index++)
        {
            //get children
        }






    }

    public void ClearRoundData()//clear arrays
    {
        index = 0;
        //for (int i = 0; i < Names.Length; i++)
        //{
        //    Names[i] = null;
        //    DidGrad[i] = false;
        //    GradTime[i] = 0;
        //    HeartCount[i] = 0;

        //}
    }


}
