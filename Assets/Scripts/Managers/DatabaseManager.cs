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
        //Router.Questions().SetValueAsync("testing 1, 2");

	}
	
	// Update is called once per frame
	void Update () {
        Router.Questions().SetValueAsync("testing 1, 2");
    }
}
 