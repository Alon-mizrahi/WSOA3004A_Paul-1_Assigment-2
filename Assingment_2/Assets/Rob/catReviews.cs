using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catReviews : MonoBehaviour
{
    public void Start()
    {
       
        //test review 
    }
    public class review
    {
        public List<string> reviewText;
        public List<string> idleReviewText;

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

        public void buildIdleReview(int heartRating , int Type)
        {
            /// heartRating is the heart value at which the idle review was called 
            /// type 0 = need was met   , type 1 = need was not met
            switch (heartRating)
            {
                case 0:
                    idleReviewText = new List<string>()
                            {
                                "bad ",
                                "un-uwu",
                                "*angry cat noises*"
                            };
                    break;
                case 1:
                    switch (Type) 
                    {
                        case 0:
                            idleReviewText = new List<string>()
                            {
                                "was good ",
                                "uwu",
                                "nyaaa , wuv u"
                            };
                            break;
                        case 1:
                            idleReviewText = new List<string>()
                            {
                                "bad ",
                                "un-uwu",
                                "*angry cat noises*"
                            };
                            break;
                    }
                    break;
                case 2:
                    switch (Type)
                    {
                        case 0:
                            idleReviewText = new List<string>()
                            {
                                "was good ",
                                "uwu",
                                "nyaaa , wuv u"
                            };
                            break;
                        case 1:
                            idleReviewText = new List<string>()
                            {
                                "bad ",
                                "un-uwu",
                                "*angry cat noises*"
                            };
                            break;
                    }
                    break;

                case 3:
                    switch (Type)
                    {
                        case 0:
                            idleReviewText = new List<string>()
                            {
                                "was good ",
                                "uwu",
                                "nyaaa , wuv u"
                            };
                            break;
                        case 1:
                            idleReviewText = new List<string>()
                            {
                                "bad ",
                                "un-uwu",
                                "*angry cat noises*"
                            };
                            break;
                    }
                    break;

                case 4:
                    switch (Type)
                    {
                        case 0:
                            idleReviewText = new List<string>()
                            {
                                "was good ",
                                "uwu",
                                "nyaaa , wuv u"
                            };
                            break;
                        case 1:
                            idleReviewText = new List<string>()
                            {
                                "bad ",
                                "un-uwu",
                                "*angry cat noises*"
                            };
                            break;
                    }
                    break;
                case 5:
                    switch (Type)
                    {
                        case 0:
                            idleReviewText = new List<string>()
                            {
                                "was good ",
                                "uwu",
                                "nyaaa , wuv u"
                            };
                            break;
                        case 1:
                            idleReviewText = new List<string>()
                            {
                                "bad ",
                                "un-uwu",
                                "*angry cat noises*"
                            };
                            break;
                    }
                    break;
                default:
                    idleReviewText = new List<string>()
                            {
                                "was good ",
                                "uwu",
                                "nyaaa , wuv u"
                            };
                    break;




            }
        }
     }

    public string getReviewText(int starRating, int personality)
    {
        review temp = new review();
        temp.buildReview(starRating, personality);
        string text = temp.reviewText[Random.Range(0, temp.reviewText.Count)]; // use this when calling review
        Debug.Log(text);
        return text;
    }

    public string getIdleReviewText(int heart, int type)
    {
        review temp = new review();
        temp.buildIdleReview(heart, type);
        string text = temp.idleReviewText[Random.Range(0, temp.idleReviewText.Count)]; // use this when calling review
        Debug.Log(text + " idle");
        return text;
    }


}
