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

        PlayerRegexomon testRegPlayer = new PlayerRegexomon("YESSSSS!", "http://fake.com", "none", "none");
        DatabaseManager.sharedInstance.CreateNewRegexomon(testRegPlayer, CurrentUserId);
    }
}
