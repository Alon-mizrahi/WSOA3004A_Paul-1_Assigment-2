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

                                //"Why did you not pay attention to me?",
                                //"*Disgusted glare.*",
                                //"I deserve more attention!"
                            };
                            break;
                        case 2:
                            reviewText = new List<string>()
                            { 

                            };
                            break;
                        case 3:
                            reviewText = new List<string>()
                            {

                            };
                            break;
                        
                        default:
                            reviewText = new List<string>()
                            {  
                                "You ignored me and I was sad.",
                                "Why did you not pay attention to me?",
                                "I deserve more attention."
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

                            };
                            break;
                        case 2:
                            reviewText = new List<string>()
                            {

                            };
                            break;
                        case 3:
                            reviewText = new List<string>()
                            {

                            };
                            break;
                        default:
                            reviewText = new List<string>()
                            {
                                "I could grow to like it here. You seem alright.",
                                "You did not give me enough cuddles.",
                                "At least the fire was warm."
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

                            };
                            break;
                        case 2:
                            reviewText = new List<string>()
                            {

                            };
                            break;
                        case 3:
                            reviewText = new List<string>()
                            {

                            };
                            break;
                        default:
                            reviewText = new List<string>()
                            {
                                "I’m comfortable for the first time in ages.",
                                "You are growing on me human.",
                                "I think we're going to get along."
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

                            };
                            break;
                        case 2:
                            reviewText = new List<string>()
                            {

                            };
                            break;
                        case 3:
                            reviewText = new List<string>()
                            {

                            };
                            break;
                        default:
                            reviewText = new List<string>()
                            {
                                "I had a great time today, and it was because of you.",
                                "Thank you human for feeding me.",
                                "*Mews in happiness*"
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

                            };
                            break;
                        case 2:
                            reviewText = new List<string>()
                            {

                            };
                            break;
                        case 3:
                            reviewText = new List<string>()
                            {

                            };
                            break;
                        default:
                            reviewText = new List<string>()
                            {
                                "You are the best human!",
                                "I will miss you. And your food.",
                                "You are the best friend I've ever had."
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
                    switch (Type)
                    {
                        case 0: //Need met
                            idleReviewText = new List<string>()
                            {
                                "Maybe there is a place for me here.",
                                "Is this what happiness feels like?",
                                "Sleep is good. I like sleep."
                            };
                            break;
                        case 1: //Need not met
                            idleReviewText = new List<string>()
                            {
                                "Nobody loves me.",
                                "I’m so hungry.",
                                "All alone…"
                            };
                            break;
                    }
                    break;

                case 1:
                    switch (Type) 
                    {
                        case 0: //Need met
                            idleReviewText = new List<string>()
                            {
                                "I'm glad I found my way here.",
                                "These other cats seem alright after all.",
                                "Thanks human!"
                            };

                            break;
                        case 1: //Need not met
                            idleReviewText = new List<string>()
                            {
                                "*angry cat noises*",
                                "Why is nobody paying attention to me?",
                                "I deserve better."
                            };
                            break;
                    }
                    break;
                case 2:
                    switch (Type)
                    {
                        case 0: //Need met
                            idleReviewText = new List<string>()
                            {
                                "The fire is bright… like my future.",
                                "This carpet is comfortable.",
                                "This human seems nice."
                            };
                            break;
                        case 1: //Need not met
                            idleReviewText = new List<string>()
                            {
                                "I hope there will be food left for me.",
                                "I require attention.",
                                "Why is the human ignoring me..."
                            };
                            break;
                    }
                    break;

                case 3:
                    switch (Type)
                    {
                        case 0: //Need met
                            idleReviewText = new List<string>()
                            {
                                "Thank you human.",
                                "Will you be my friend?",
                                "The other cats are fun to play with."
                            };
                            break;
                        case 1: //Need not met
                            idleReviewText = new List<string>()
                            {
                                "I thought the human loved me.",
                                "Meow.",
                                "*sad cat noises*"
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
                                "I love this human!",
                                "I’ve never been this happy before.",
                                "*Purrs in contentment.*"
                            };
                            break;
                        case 1:
                            idleReviewText = new List<string>()
                            {
                                "I have not been petted in minutes. I am disappointed.",
                                "Don't you care about me?",
                                "Guess I'll just keep myself company then."
                            };
                            break;
                    }
                    break;

                default:
                    idleReviewText = new List<string>()
                            {
                                "Meow.",
                                "I require attention.",
                                "Sleep is good. I like sleep."
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
