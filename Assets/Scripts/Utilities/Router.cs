using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;  //allows us to interact with the database

public class Router : MonoBehaviour {

    private static DatabaseReference baseRef = FirebaseDatabase.DefaultInstance.RootReference;

    public static DatabaseReference Players()
    {
        return baseRef.Child("Players");
    }
    public static DatabaseReference PlayerWithUID(string uid)
    {
        return baseRef.Child("Players").Child(uid);
    }


    public static DatabaseReference Regexomons()
    {
        return baseRef.Child("Regexomon");
    }
    public static DatabaseReference RegexomonsWithID(string id)
    {
        return baseRef.Child("Regexomon").Child(id);
    }


    public static DatabaseReference GetLevelOneQuestions()
    {
        return baseRef.Child("Level1-Questions");
    }
    public static DatabaseReference GetQuestion(string questId)
    {
        return baseRef.Child("Level1-Questions").Child(questId);
    }
}
