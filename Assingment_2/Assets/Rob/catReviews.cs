using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catReviews : MonoBehaviour
{
    public void Start()
    {
        review temp = new review();
        temp.buildReview(0, 1);
        string text = temp.reviewText[Random.Range(0 , temp.reviewText.Count)]; // use this when calling review
        Debug.Log(text);
        //test review 
    }
    public class review
    {
        public List<string> reviewText;

            public void buildReview(int starRating , int Personality)
            {
             switch (starRating)
            {
                case 0:
                    
                    switch (Personality)
                    {
                        case 1:
                            reviewText = new List<string>()
                            {
                                /// basically this is a list 
                                /// so you can have more than 1 response personality type per star rating
                                /// personality types are just a broad way of catagorising who says what review so just come up with some
                                /// eg. 1 = lazy cat , 2 = angry cat , 3 happy cat , etc
                                /// default is for if you dont want to make one for a specific personality type -> it will then forward to this review list 
                                /// 
                                /// here the cat can say these 3 options
                                /// so just write what lines , if you want another line just add a comma , it uses standard rtf formating
                                /// if you want more than 1 line in the review use +\n or look it up
                                /// oki 
                                /// 



                                "uwu",
                                "cheese",
                                "was shit service , literal excrament "
                            };
                            break;
                        case 2:
                            reviewText = new List<string>()
                            { 
                                "uwu",
                                "cheese",
                                "was shit service , literal excrament "
                            };
                            break;
                        case 3:
                            reviewText = new List<string>()
                            {
                                "uwu",
                                "cheese",
                                "was shit service , literal excrament "
                            };
                            break;
                        default:
                            reviewText = new List<string>()
                            {  
                                "uwu",
                                "cheese",
                                "was shit service , literal excrament "
                            };
                            break;
                    }
                    break;
                case 1:
                    switch (Personality)
                    {
                        case 1:
                            reviewText = new List<string>()
                            {
                                "uwu",
                                "cheese",
                                "was shit service , literal excrament "
                            };
                            break;
                        case 2:
                            reviewText = new List<string>()
                            {
                                "uwu",
                                "cheese",
                                "was shit service , literal excrament "
                            };
                            break;
                        case 3:
                            reviewText = new List<string>()
                            {
                                "uwu",
                                "cheese",
                                "was shit service , literal excrament "
                            };
                            break;
                        default:
                            reviewText = new List<string>()
                            {
                                "uwu",
                                "cheese",
                                "was shit service , literal excrament "
                            };
                            break;
                    }
                    break;
                case 2:
                    switch (Personality)
                    {
                        case 1:
                            reviewText = new List<string>()
                            {
                                "uwu",
                                "cheese",
                                "was shit service , literal excrament "
                            };
                            break;
                        case 2:
                            reviewText = new List<string>()
                            {
                                "uwu",
                                "cheese",
                                "was shit service , literal excrament "
                            };
                            break;
                        case 3:
                            reviewText = new List<string>()
                            {
                                "uwu",
                                "cheese",
                                "was shit service , literal excrament "
                            };
                            break;
                        default:
                            reviewText = new List<string>()
                            {
                                "uwu",
                                "cheese",
                                "was shit service , literal excrament "
                            };
                            break;
                    }
                    break;
                case 3:
                    switch (Personality)
                    {
                        case 1:
                            reviewText = new List<string>()
                            {
                                "uwu",
                                "cheese",
                                "was shit service , literal excrament "
                            };
                            break;
                        case 2:
                            reviewText = new List<string>()
                            {
                                "uwu",
                                "cheese",
                                "was shit service , literal excrament "
                            };
                            break;
                        case 3:
                            reviewText = new List<string>()
                            {
                                "uwu",
                                "cheese",
                                "was shit service , literal excrament "
                            };
                            break;
                        default:
                            reviewText = new List<string>()
                            {
                                "uwu",
                                "cheese",
                                "was shit service , literal excrament "
                            };
                            break;
                    }
                    break;
                case 4:
                    switch (Personality)
                    {
                        case 1:
                            reviewText = new List<string>()
                            {
                                "uwu",
                                "cheese",
                                "was shit service , literal excrament "
                            };
                            break;
                        case 2:
                            reviewText = new List<string>()
                            {
                                "uwu",
                                "cheese",
                                "was shit service , literal excrament "
                            };
                            break;
                        case 3:
                            reviewText = new List<string>()
                            {
                                "uwu",
                                "cheese",
                                "was shit service , literal excrament "
                            };
                            break;
                        default:
                            reviewText = new List<string>()
                            {
                                "uwu",
                                "cheese",
                                "was shit service , literal excrament "
                            };
                            break;
                    }
                    break;
                case 5:
                    switch (Personality)
                    {
                        case 1:
                            reviewText = new List<string>()
                            {
                                "uwu",
                                "cheese",
                                "was shit service , literal excrament "
                            };
                            break;
                        case 2:
                            reviewText = new List<string>()
                            {
                                "uwu",
                                "cheese",
                                "was shit service , literal excrament "
                            };
                            break;
                        case 3:
                            reviewText = new List<string>()
                            {
                                "uwu",
                                "cheese",
                                "was shit service , literal excrament "
                            };
                            break;
                        default:
                            reviewText = new List<string>()
                            {
                                "uwu",
                                "cheese",
                                "was shit service , literal excrament "
                            };
                            break;
                    }
                    break;

            }
            }
     }
}
