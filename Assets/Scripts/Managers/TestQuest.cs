using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Auth;


public class TestQuest : MonoBehaviour
{
    //Trying to get access to single user


    //public static List<QuestionSet> levelOneQuestions = new List<QuestionSet>();

    void Awake()
    {
        var CurrentUserId = FirebaseAuth.DefaultInstance.CurrentUser.UserId;
        Debug.Log("CurrentUserId" + CurrentUserId);


        Router.PlayerWithUID(CurrentUserId).GetValueAsync().ContinueWith(task =>
        {
            DataSnapshot user = task.Result;
            Debug.Log("user : " + user);
            foreach (DataSnapshot player in user.Children)
            {
                var playerDictionary = (IDictionary<string, object>)user.Value;

                Debug.Log("What is the playerDictionary : " + playerDictionary);

                Player newPlayer = new Player(playerDictionary);
                Debug.Log("What is the new Player : " + newPlayer);
                //levelOneQuestions.Add(newPlayer);
            }
        });

    }

}

















//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Firebase;
//using Firebase.Auth;
//using System.Threading.Tasks;


//public class TestQuest : MonoBehaviour {

//    /*
//    Use QuestionManager.levelOneQuestions in you code to access the questions from the database
//    QuestionManager runs when login screen appears. It needs to run here because 
//    QuestionManager.levelOneQuestions needs to get it's data before use
//    */

//    //this file is just for practice, and can be removed
//    void Awake () {
//        var CurrentUserId = FirebaseAuth.DefaultInstance.CurrentUser.UserId;
//        Debug.Log("CurrentUserId" + CurrentUserId);
//        //Debug.Log("questionsCout: " + QuestionManager.levelOneQuestions.Count);
//        //Debug.Log("question 1: " + QuestionManager.levelOneQuestions[0].question);
//        //Debug.Log("answer 1: " + QuestionManager.levelOneQuestions[0].right);
//        //Debug.Log("wrong choice 1: " + QuestionManager.levelOneQuestions[0].wrong[0]);
//        //Debug.Log("wrong choice 2: " + QuestionManager.levelOneQuestions[0].wrong[1]);
//        //Debug.Log("wrong choice 3: " + QuestionManager.levelOneQuestions[0].wrong[2]); 
//    }
//}
