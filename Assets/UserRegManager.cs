using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Auth;

public class UserRegManager : MonoBehaviour {
    public static List<PlayerRegexomon> regexomonList = new List<PlayerRegexomon>();
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
            }

        });

        //List<PlayerRegexomon> updatedRegexomonList = regexomonList;
        PlayerRegexomon testRegPlayer = new PlayerRegexomon("ItWillWork!!", "http://fake.com", "none", "none");
        DatabaseManager.sharedInstance.CreateNewRegexomon(testRegPlayer, CurrentUserId, regexomonList.Count);
        //updatedRegexomonList.Add(testRegPlayer);
        //string json = testRegPlayer.ToDictionary();
        //.SetRawJsonValueAsync(json);
        //DatabaseManager.sharedInstance.CreateNewPlayer(player, newPlayer.UserId);
        //Router.PlayerWithUID(CurrentUserId).Child("score").SetValueAsync(20);

        //Dictionary<string, Object> entryValues = entry.ToDictionary();

        //var key = Router.PlayerWithUID(CurrentUserId).Child("regexomon").Push().Key; //<<to add a key


        //Router.PlayerWithUID(CurrentUserId).Child("regexomon").SetValueAsync(json);
    }
    //public void CreateNewRegexomon(PlayerRegexomon regex, string uid)
    //{
    //    string playerJSON = JsonUtility.ToJson(regex);
    //    string test = "1";
    //    Router.PlayerWithUID(uid).Child("regexomon").Child(test).SetRawJsonValueAsync(playerJSON);
    //}
}
