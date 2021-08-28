using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catGen : MonoBehaviour
{

    public Color[] catPartColor; // white , brown , grey , black , orange , choc , pink , green , red , schwartz , blue , yellow;

    public GameObject[] catPart; //head , face , eye1 , eye2 , ears , upperT , lowerT , tail , legs : UL , UR , LL , LR

    public Sprite[] catHead; //reg , fluff , chonk
    public Sprite[] catUTorso; // reg , fluff
    public Sprite[] catLTorso; // reg , chock , fluff
    public Sprite[] catfaceParts; //expression , eye 1 , eye 2 ;
    public Sprite[] catEars; // reg , fluff , fold
    public Sprite[] catLegTParts; //Fr r , l , back r , l ;
    public Sprite[] catLegCParts; //Fr r , l , back r , l ;
    public Sprite[] catTailPart; //reg , chonk , fluff , ball


    // Start is called before the first frame update
    void Start()
    {
        ColorCat(catPartColor[3]);
        ColorCatEyesL(catPartColor[10]);
        ColorCatEyesR(catPartColor[10]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ColorCat(Color color)
    {
        catPart[0].GetComponent<SpriteRenderer>().color = color;
        catPart[1].GetComponent<SpriteRenderer>().color = color;
        catPart[4].GetComponent<SpriteRenderer>().color = color;
        catPart[5].GetComponent<SpriteRenderer>().color = color;
        catPart[6].GetComponent<SpriteRenderer>().color = color;
        catPart[7].GetComponent<SpriteRenderer>().color = color;
        catPart[8].GetComponent<SpriteRenderer>().color = color;
        catPart[9].GetComponent<SpriteRenderer>().color = color;
        catPart[10].GetComponent<SpriteRenderer>().color = color;
        catPart[11].GetComponent<SpriteRenderer>().color = color;
    }

    void ColorCatEyesL(Color color)
    {
        catPart[2].GetComponent<SpriteRenderer>().color = color;
    }

    void ColorCatEyesR(Color color)
    {
        catPart[3].GetComponent<SpriteRenderer>().color = color;
    }
}
