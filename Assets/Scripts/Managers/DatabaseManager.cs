using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager sharedInstance = null;

    void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else if (sharedInstance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://regexomon.firebaseio.com/");

    }

    public void CreateNewPlayer(Player player, string uid)
    {
        string playerJSON = JsonUtility.ToJson(player);
        //could also pass a ditionary or singal value in SetRawJsonValueAsync
        Router.PlayerWithUID(uid).SetRawJsonValueAsync(playerJSON);
    }

    public void GetAllPlayers(Action<List<Player>> completePlayers)
    {
        List<Player> tempList = new List<Player>();
        Router.Players().GetValueAsync().ContinueWith(task =>
        {
            DataSnapshot players = task.Result;
            foreach (DataSnapshot player in players.Children)
            {
                var playerDictionary = (IDictionary<string, object>)player.Value;
                Player newPlayer = new Player(playerDictionary);
                tempList.Add(newPlayer);
            }
            completePlayers(tempList);
        });

    }

}