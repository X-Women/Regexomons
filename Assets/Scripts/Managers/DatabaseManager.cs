using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

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
        Debug.Log(Router.Questions());
        Debug.Log(Router.Users());

    }
	
	public void CreateNewUser(User1 user, string uId)
    {
        string userJSON = JsonUtility.ToJson(user);
        //could also pass a ditionary or singal value in SetRawJsonValueAsync
        Router.UserWithID(uId).SetRawJsonValueAsync(userJSON);
    }
}
 