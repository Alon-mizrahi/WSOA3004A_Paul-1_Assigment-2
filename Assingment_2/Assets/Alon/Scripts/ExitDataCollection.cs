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
    public List<string> catEndReviews;
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
        Cat.GetComponent<CatClickAndDrag>().enabled = false;
        Cat.transform.SetParent(gameObject.transform);
        //Debug.Log("pause");
        Cat.transform.localPosition = new Vector3(0, 0, 0);

        Cat.GetComponent<CatWander>().enabled = false;
        
        Cat.GetComponent<Petting>().enabled = false;
        Cat.GetComponent<CatObject>().enabled = false;//?? can we still access data?

    }



    public void GetCatData()
    {
        TotalCats = transform.childCount;
        CatList = new CatObject[TotalCats];

        CatList = GetComponentsInChildren<CatObject>();


        foreach (Transform Cat in gameObject.transform)
        {
            Debug.Log("DATA: " + Cat.gameObject.name + " | " + Cat.GetComponent<CatObject>().gradReady + " | " + Cat.GetComponent<CatObject>().heartCount + " | " + Cat.GetComponent<CatObject>().totalGraduationTime);
            catEndReviews.Add("'" + Cat.GetComponent<CatObject>().getEndReview() + "'" + "\n \n --" + Cat.GetComponent<CatObject>().Name);
            //call function to give data to
        }




        //for (index = 0; index <= TotalCats; index++)
        //{

        //get children
        //}






    }

    public void ClearRoundData()//clear arrays
    {
        index = 0;
        foreach (Transform child in gameObject.transform) { GameObject.Destroy(child.gameObject); }
    }


}
