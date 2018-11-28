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

    //void Awake()
    //{
    //    var CurrentUserId = UserIdManager.CurrentUserId;

    //    //Gets player Regexomon

    //    Router.PlayerWithUID(CurrentUserId).Child("regexomon").GetValueAsync().ContinueWith(task =>
    //    {
    //        DataSnapshot regexomons = task.Result;
    //        foreach (DataSnapshot regexomon in regexomons.Children)
    //        {
    //            var regDictionary = (IDictionary<string, object>)regexomon.Value;

    //            PlayerRegexomon newPlayerRegexomon = new PlayerRegexomon(regDictionary);
    //            Debug.Log(newPlayerRegexomon.name);
    //        }

    //    });

    //   // Gets player Level

    //    Router.PlayerWithUID(CurrentUserId).Child("level").GetValueAsync().ContinueWith(task =>
    //    {
    //        Debug.Log("Working!!");
    //        DataSnapshot level = task.Result;
    //        var levelDictionary = (IDictionary<string, object>)level.Value;
    //        var lev = levelDictionary["level"].ToString();
    //        Debug.Log("Am I getting the score:" + lev);



    //    });


    //}

}
