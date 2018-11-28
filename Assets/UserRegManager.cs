using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Auth;

public class UserRegManager : MonoBehaviour {
    public static List<PlayerRegexomon> regexomonList = new List<PlayerRegexomon>();
    public static string email;
    public static int level;
    public static int score;

    // Use this for initialization
    void Awake()
    {
        regexomonList.Clear();

        var CurrentUserId = UserIdManager.CurrentUserId;

        Router.PlayerWithUID(CurrentUserId).Child("regexomon").GetValueAsync().ContinueWith(task =>
        {
            DataSnapshot regexomons = task.Result;
            foreach (DataSnapshot regexomon in regexomons.Children)
            {
                var regDictionary = (IDictionary<string, object>)regexomon.Value;
                PlayerRegexomon newPlayerRegexomon = new PlayerRegexomon(regDictionary);
                regexomonList.Add(newPlayerRegexomon);
                Debug.Log("name: " + newPlayerRegexomon.name);
            }

        });


        Router.PlayerWithUID(CurrentUserId).GetValueAsync().ContinueWith(task =>
        {
            DataSnapshot player = task.Result;
            var playerDictionary = (IDictionary<string, object>)player.Value;
            Player gotPlayer = new Player(playerDictionary);
            email = gotPlayer.email;
            level = gotPlayer.level;
            score = gotPlayer.score;

        });
    }
}
