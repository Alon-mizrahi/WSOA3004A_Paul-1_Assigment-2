using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catGen : MonoBehaviour
{

    public Color[] catPartColor; // white 0, brown 1, grey 2, black 3, orange 4, choc 5, pink , green 7, red 8, schwartz 9, blue 10, yellow 11;
    public Color storedCatColor;

    public GameObject[] catPart; //head , face , eye1 , eye2 , ears , upperT , lowerT , tail , legs : UL , UR , LL , LR
    public GameObject[] catFancyPart;

    public Sprite[] catHead; //reg , fluff , chonk
    public Sprite[] catUTorso; // reg , fluff
    public Sprite[] catLTorso; // reg , chock , fluff
    public Sprite[] catfaceParts; //expression , eye 1 , eye 2 ;
    public Sprite[] catEars; // reg , fluff , fold
    public Sprite[] catLegTParts; //Fr r , l , back r , l ;
    public Sprite[] catLegCParts; //Fr r , l , back r , l ;
    public Sprite[] catTailPart; //reg , chonk , fluff , ball
    public Sprite[] catEyes; // reg 0 ,1 , fat 2 ,3;
    public Sprite[] catStripes;
    public Sprite[] catBlotches;

    public int catbaseColor ,catColorIndex , catBodyRoll ,catFancy ,catCount , catThres;
    public Sprite catEmpty;
    public bool catmarellaDans , isFat;

    // head , front torso , tail , front legs , face , ears
    // remove everything else : lower legts , lower torso , eyes 


    // Start is called before the first frame update
    void Start()
    {
        GenerateCat();



    }

    // Update is called once per frame
    void Update()
    {
        catmarellaDancing();
    }

    private void catmarellaDancing()
    {
        if(catmarellaDans)
        {
            catCount++;
            if (catCount == 1)
            {
                GenerateCat();
            }

            if (catCount < catThres)
            {
                resetCat();
                catCount = 0;
            }
        }
    }

    private void GenerateCat() 
    {
        catBodyRoll = Random.Range(0, 101);
        catbaseColor = Random.Range(0, 101);
        catFancy = Random.Range(0, 100);
        catColorIndex = getCatColorIndex(catbaseColor);
        ColorCat(drawCatColor(catbaseColor));
        drawCatEyeColor();
        catEar();
        catFaceGen();
        catBody();
        hasSocks();
        multiEar();
        isCatFancy();
    }
    private void resetCat()
    {
        //head 0, face 1, eye1 2, eye2 3, ears 4, upperT 5, lowerT 6, tail 7, legs : UL 8, UR 9, LL 10, LR 11
        catPart[0].GetComponent<SpriteRenderer>().enabled = true;
        catPart[1].GetComponent<SpriteRenderer>().enabled = true;
        catPart[2].GetComponent<SpriteRenderer>().enabled = true;
        catPart[3].GetComponent<SpriteRenderer>().enabled = true;
        catPart[4].GetComponent<SpriteRenderer>().enabled = true;
        catPart[5].GetComponent<SpriteRenderer>().enabled = true;
        catPart[6].GetComponent<SpriteRenderer>().enabled = true;
        catPart[7].GetComponent<SpriteRenderer>().enabled = true;
        catPart[8].GetComponent<SpriteRenderer>().enabled = true;
        catPart[9].GetComponent<SpriteRenderer>().enabled = true;
        catPart[10].GetComponent<SpriteRenderer>().enabled = true;
        catPart[11].GetComponent<SpriteRenderer>().enabled = true;


        catPart[0].GetComponent<SpriteRenderer>().sprite = catHead[0];
        catPart[1].GetComponent<SpriteRenderer>().sprite = catfaceParts[0];
        catPart[2].GetComponent<SpriteRenderer>().sprite = catEyes[0];
        catPart[3].GetComponent<SpriteRenderer>().sprite = catEyes[1];
        catPart[4].GetComponent<SpriteRenderer>().sprite = catEars[0];
        catPart[5].GetComponent<SpriteRenderer>().sprite = catUTorso[0];
        catPart[6].GetComponent<SpriteRenderer>().sprite = catLTorso[0];
        catPart[7].GetComponent<SpriteRenderer>().sprite = catTailPart[0];
        catPart[8].GetComponent<SpriteRenderer>().sprite = catLegTParts[0];
        catPart[9].GetComponent<SpriteRenderer>().sprite = catLegTParts[1];
        catPart[10].GetComponent<SpriteRenderer>().sprite = catLegTParts[2];
        catPart[11].GetComponent<SpriteRenderer>().sprite = catLegTParts[3];
    }

    void isCatFancy()
    {
        // white 0, brown 1, grey 2, black 3, orange 4, choc 5;
        switch (catColorIndex)
        {
            case 0:
                //highest chance to get blotches or stripes
                colorMarks(1, 6 , true , true);
                break;
            case 1:
                colorMarks(1, 3 , false , true);
                break;
            case 2:
                colorMarks(0, 3, true, true);
                break;
            case 3:
                colorMarks(0, 0, false, true);
                break;
            case 4:
                colorMarks(1, 3, true, true);
                break;
            case 5:
                colorMarks(0, 3, false, true);
                break;
        }
    }

    void colorMarks(int start , int end , bool canGetStripes , bool canGetBlotches)
    {
  



        catFancyPart[0].GetComponent<SpriteRenderer>().enabled = false;
        catFancyPart[1].GetComponent<SpriteRenderer>().enabled = false;
        catFancyPart[2].GetComponent<SpriteRenderer>().enabled = false;

        if(canGetStripes)
        {
            if ((catFancy > 70) && (catFancy <= 85))
            {
                if (catBodyRoll > 90)
                {
                    catFancyPart[0].GetComponent<SpriteRenderer>().sprite = catStripes[3];
                    catFancyPart[1].GetComponent<SpriteRenderer>().sprite = catStripes[4];
                    catFancyPart[2].GetComponent<SpriteRenderer>().sprite = catStripes[5];
                }
                else
                {
                    catFancyPart[0].GetComponent<SpriteRenderer>().sprite = catStripes[0];
                    catFancyPart[1].GetComponent<SpriteRenderer>().sprite = catStripes[1];
                    catFancyPart[2].GetComponent<SpriteRenderer>().sprite = catStripes[2];
                }
                //cat has stripes
                catFancyPart[0].GetComponent<SpriteRenderer>().enabled = true;
                catFancyPart[1].GetComponent<SpriteRenderer>().enabled = true;
                catFancyPart[2].GetComponent<SpriteRenderer>().enabled = true;

                int catMarkColor = Random.Range(start, end);

                catFancyPart[0].GetComponent<SpriteRenderer>().color = catPartColor[catMarkColor];
                catFancyPart[1].GetComponent<SpriteRenderer>().color = catPartColor[catMarkColor];
                catFancyPart[2].GetComponent<SpriteRenderer>().color = catPartColor[catMarkColor];
            }
        }

        if(canGetBlotches)
        {
            if ((catFancy > 85) && (catFancy <= 100))
            {
                if (catBodyRoll > 90)
                {
                    catFancyPart[0].GetComponent<SpriteRenderer>().sprite = catBlotches[3];
                    catFancyPart[1].GetComponent<SpriteRenderer>().sprite = catBlotches[4];
                    catFancyPart[2].GetComponent<SpriteRenderer>().sprite = catBlotches[5];
                }
                else
                {
                    catFancyPart[0].GetComponent<SpriteRenderer>().sprite = catBlotches[0];
                    catFancyPart[1].GetComponent<SpriteRenderer>().sprite = catBlotches[1];
                    catFancyPart[2].GetComponent<SpriteRenderer>().sprite = catBlotches[2];
                }
                //cat has stripes
                catFancyPart[0].GetComponent<SpriteRenderer>().enabled = true;
                catFancyPart[1].GetComponent<SpriteRenderer>().enabled = true;
                catFancyPart[2].GetComponent<SpriteRenderer>().enabled = true;

                int catMarkColor = Random.Range(start, end);

                catFancyPart[0].GetComponent<SpriteRenderer>().color = catPartColor[catMarkColor];
                catFancyPart[1].GetComponent<SpriteRenderer>().color = catPartColor[catMarkColor];
                catFancyPart[2].GetComponent<SpriteRenderer>().color = catPartColor[catMarkColor];
            }
        }
    }

    void ColorCat(Color color)
    {
        catPart[0].GetComponent<SpriteRenderer>().color = color;
        catPart[4].GetComponent<SpriteRenderer>().color = color;
        catPart[5].GetComponent<SpriteRenderer>().color = color;
        catPart[6].GetComponent<SpriteRenderer>().color = color;
        catPart[7].GetComponent<SpriteRenderer>().color = color;
        catPart[8].GetComponent<SpriteRenderer>().color = color;
        catPart[9].GetComponent<SpriteRenderer>().color = color;
        catPart[10].GetComponent<SpriteRenderer>().color = color;
        catPart[11].GetComponent<SpriteRenderer>().color = color;
    }

    void catFaceGen()
    {
        int faceDraw = Random.Range(1, 11);

        if(faceDraw <= 8)
        {
            catPart[1].GetComponent<SpriteRenderer>().sprite = catfaceParts[0];
        }

        if(faceDraw == 9)
        {
            catPart[1].GetComponent<SpriteRenderer>().sprite = catfaceParts[1];
            catPart[2].GetComponent<SpriteRenderer>().enabled = false;
            catPart[3].GetComponent<SpriteRenderer>().enabled = false;
        }

        if (faceDraw == 10)
        {
            catPart[1].GetComponent<SpriteRenderer>().sprite = catfaceParts[3];
        }
    }
    void ColorCatEyesL(Color color)
    {
        catPart[2].GetComponent<SpriteRenderer>().color = color;
    }

    void ColorCatEyesR(Color color)
    {
        catPart[3].GetComponent<SpriteRenderer>().color = color;
    }

    private int getCatColorIndex(int catBase)
    {
        if ((catBase > 0) && (catBase <= 75))
        {
            int coat = Random.Range(1, 5);
            switch (coat)
            {
                case 1:
                    return 0;
                case 2:
                    return 1;
                case 3:
                    return 2;
                case 4:
                    return 4;


            }
        }

        if ((catBase > 75) && (catBase <= 95))
        {
            // white 0, brown 1, grey 2, black 3, orange 4, choc 5;
       
            return 5;
        }

        if ((catBase > 95) && (catBase <= 100))
        {
            return 3;
        }

        return 0;
    }
    private Color drawCatColor(int catBase)
    {
        if((catBase > 0) && (catBase <= 75))
        {
            int coat = Random.Range(1, 5);
            switch (coat)
            {
                case 1:

                    return catPartColor[0];
                    
                case 2:
                    return catPartColor[1];
                    
                case 3:
                    return catPartColor[2];
                    
                case 4:
                    return catPartColor[4];
                    

            }
        }

        if ((catBase > 75) && (catBase <= 95))
        {
            // white 0, brown 1, grey 2, black 3, orange 5, choc 6, pink , green 7, red 8, schwartz 9, blue 10, yellow 11;
            int glowEyecoat = Random.Range(0, 4);
            switch (glowEyecoat)
            {
                case 0:
                    ColorCatEyesL(catPartColor[7]);
                    ColorCatEyesR(catPartColor[7]);
                    break;
                case 1:
                    ColorCatEyesL(catPartColor[10]);
                    ColorCatEyesR(catPartColor[10]);
                    break;
                case 2:
                    ColorCatEyesL(catPartColor[8]);
                    ColorCatEyesR(catPartColor[8]);
                    break;
                case 3:
                    ColorCatEyesL(catPartColor[10]);
                    ColorCatEyesR(catPartColor[10]);
                    break;

            }
            return catPartColor[5];
        }

        if ((catBase > 95) && (catBase <= 100))
        {
            return catPartColor[3];

            int glowEyecoat = Random.Range(0, 4);
            switch (glowEyecoat)
            {
                case 0:
                    ColorCatEyesL(catPartColor[7]);
                    ColorCatEyesR(catPartColor[7]);
                    break;
                case 1:
                    ColorCatEyesL(catPartColor[10]);
                    ColorCatEyesR(catPartColor[10]);
                    break;
                case 2:
                    ColorCatEyesL(catPartColor[8]);
                    ColorCatEyesR(catPartColor[8]);
                    break;
                case 3:
                    ColorCatEyesL(catPartColor[10]);
                    ColorCatEyesR(catPartColor[10]);
                    break;

            }
            return catPartColor[5];
        }

        return catPartColor[0];
    }

    void catType()
    {
        int catType = Random.Range(0, 11);

        if (catType > 7)
        {
            int fancyCatType = Random.Range(0, 3);

            switch (fancyCatType) 
            {
                case 0:

                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
        }
        
    }

    void drawCatEyeColor()
    {
        int heterochromia = Random.Range(0, 11);
        if(heterochromia > 6)
        {
            //has heterochromia
            int catFancyDraw = Random.Range(6, 10);
            int catFancyDraw2 = Random.Range(6, 10);

            ColorCatEyesL(catPartColor[catFancyDraw]);
            ColorCatEyesR(catPartColor[catFancyDraw2]);
        }
        else
        {
            int catEyeDraw = Random.Range(0,101);
            if ((catEyeDraw > 0) && (catEyeDraw <= 50))
            {

                ColorCatEyesL(catPartColor[8]);
                ColorCatEyesR(catPartColor[8]);
            }

            if ((catEyeDraw > 50) && (catEyeDraw <= 100))
            {
                int catFancyDraw = Random.Range(6, 10);

                ColorCatEyesL(catPartColor[catFancyDraw]);
                ColorCatEyesR(catPartColor[catFancyDraw]);
            }
        }
    }

    void catBody()
    {

        if (catBodyRoll > 65)
        {
            //head 0, face 1, eye1 2, eye2 3, ears 4, upperT 5, lowerT 6, tail 7, legs : UL 8, UR 9, LL 10, LR 11

            if((catBodyRoll >65) && (catBodyRoll <= 75))
            {
                //fluff cat
                catPart[0].GetComponent<SpriteRenderer>().sprite = catHead[1];
                catPart[5].GetComponent<SpriteRenderer>().sprite = catUTorso[1];
                catPart[6].GetComponent<SpriteRenderer>().sprite = catLTorso[1];
                catPart[7].GetComponent<SpriteRenderer>().sprite = catTailPart[2];
            }

            if ((catBodyRoll > 75) && (catBodyRoll < 90))
            {
                //thicc cat
                catPart[0].GetComponent<SpriteRenderer>().sprite = catHead[2];
                catPart[4].GetComponent<SpriteRenderer>().sprite = catEars[1];
                catPart[5].GetComponent<SpriteRenderer>().sprite = catUTorso[0];
                catPart[6].GetComponent<SpriteRenderer>().sprite = catLTorso[2];
                catPart[7].GetComponent<SpriteRenderer>().sprite = catTailPart[1];
            }

            if ((catBodyRoll >= 90) && (catBodyRoll <= 100))
            {
                //fat cat meow

                //head 0, face 1, eye1 2, eye2 3, ears 4, upperT 5, lowerT 6, tail 7, legs : UL 8, UR 9, LL 10, LR 11

                // head , front torso , tail , front legs , face , ears
                // remove everything else : lower legts , lower torso , eyes 

                catPart[0].GetComponent<SpriteRenderer>().sprite = catHead[3];
                catPart[1].GetComponent<SpriteRenderer>().sprite = catfaceParts[2];
                catPart[2].GetComponent<SpriteRenderer>().sprite = catEyes[2];
                catPart[3].GetComponent<SpriteRenderer>().sprite = catEyes[3];
                catPart[4].GetComponent<SpriteRenderer>().sprite = catEars[4];
                catPart[5].GetComponent<SpriteRenderer>().sprite = catUTorso[2];
                catPart[6].GetComponent<SpriteRenderer>().sprite = catEmpty;
                catPart[7].GetComponent<SpriteRenderer>().sprite = catTailPart[3];
                catPart[8].GetComponent<SpriteRenderer>().enabled = false;
                catPart[9].GetComponent<SpriteRenderer>().enabled = false;
                catPart[10].GetComponent<SpriteRenderer>().enabled = false;
                catPart[11].GetComponent<SpriteRenderer>().enabled = false;

                

                if(catBodyRoll > 96)
                {
                    
                    catPart[1].GetComponent<SpriteRenderer>().sprite = catfaceParts[4];
                }

            }
        }
        else
        {
            catPart[0].GetComponent<SpriteRenderer>().sprite = catHead[0];
            catPart[5].GetComponent<SpriteRenderer>().sprite = catUTorso[0];
            catPart[6].GetComponent<SpriteRenderer>().sprite = catLTorso[0];
            catPart[7].GetComponent<SpriteRenderer>().sprite = catTailPart[0];
        }
    }
    void catEar()
    {
        int catEarRoll = Random.Range(0, 4);
        catPart[4].GetComponent<SpriteRenderer>().sprite = catEars[catEarRoll];
    }

    void hasSocks()
    {
        int catHasSocks = Random.Range(0, 100);

        if(catHasSocks > 85) 
        {
            int catSockColor = Random.Range(0, 6);
            catPart[8].GetComponent<SpriteRenderer>().color = catPartColor[catSockColor];
            catPart[9].GetComponent<SpriteRenderer>().color = catPartColor[catSockColor];
            catPart[10].GetComponent<SpriteRenderer>().color = catPartColor[catSockColor];
            catPart[11].GetComponent<SpriteRenderer>().color = catPartColor[catSockColor];

            if (catHasSocks > 90)
            {
                catPart[7].GetComponent<SpriteRenderer>().color = catPartColor[catSockColor];
            }
            else
            {
                int catTailColor = Random.Range(0, 6);
                catPart[7].GetComponent<SpriteRenderer>().color = catPartColor[catTailColor];
            }
        }
    }

    void multiEar()
    {
        int catMultiEar = Random.Range(0, 100);

        if (catMultiEar > 90)
        {
            int catSockColor = Random.Range(0, 6);
            catPart[4].GetComponent<SpriteRenderer>().color = catPartColor[catSockColor];
        }
    }

}
