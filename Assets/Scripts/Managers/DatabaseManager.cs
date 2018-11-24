using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System;

public class DatabaseManager : MonoBehaviour {
    public static DatabaseManager sharedInstance = null;

	void Awake () {
        if(sharedInstance == null) {
            sharedInstance = this;
        } else if (sharedInstance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://regexomon.firebaseio.com/");

        Debug.Log(Router.Players());
    }
	
	public void CreateNewPlayer(Player player, string uid)
    {
        string playerJSON = JsonUtility.ToJson(player);
        //could also pass a ditionary or singal value in SetRawJsonValueAsync
        Router.PlayerWithUID(uid).SetRawJsonValueAsync(playerJSON);
    }

    public void GetPlayers(Action<List<Player>> completionBlock) {
        List<Player> tmpList = new List<Player>();

        Router.Players ().GetValueAsync ().ContinueWith(task =>
        {
            DataSnapshot players = task.Result;

            foreach(DataSnapshot playerNode in players.Children) {
                var playerDict = (IDictionary<string, object>)playerNode.Value;
                Player newPlayer = new Player (playerDict);
                tmpList.Add(newPlayer);
            }
            completionBlock(tmpList);

        });
    }
}
 