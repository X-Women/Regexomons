using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Auth;


public class GetPlayerRegexomon : MonoBehaviour
{
    //Trying to get access to single user

     //public static List<PlayerRegexomon> regexomonList = new List<PlayerRegexomon>();

    void Awake()
    {
        var CurrentUserId = UserIdManager.CurrentUserId;

        //Gets player Regexomon

        Router.PlayerWithUID(CurrentUserId).Child("regexomon").GetValueAsync().ContinueWith(task =>
        {
            DataSnapshot regexomons = task.Result;
            foreach (DataSnapshot regexomon in regexomons.Children)
            {
                var regDictionary = (IDictionary<string, object>)regexomon.Value;
                PlayerRegexomon newPlayerRegexomon = new PlayerRegexomon(regDictionary);
                Debug.Log("Are these the children?" + newPlayerRegexomon.name);
            }

        });

        //Gets player Regexomon

        //Router.PlayerWithUID(CurrentUserId).Child("level").GetValueAsync().ContinueWith(task =>
        //{
        //    DataSnapshot user = task.Result;

        //    var playerDictionary = (IDictionary<string, object>)user.Value;
        //    Debug.Log("What is the playerDictionary : " + playerDictionary); //logs What is the playerDictionary : System.Collections.Generic.Dictionary`2[System.String,System.Object]
        //    Player newPlayer = new Player(playerDictionary);
        //    Debug.Log("What is the new Player : " + newPlayer); //logs nothing 
        //});


    }

}
