using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;


public class PlayerRegexomonManager : MonoBehaviour
{
    public Text idString;

    public void Config(Firebase.Auth.FirebaseUser user) 
    {
        this.idString.text = string.Format("You are signed in as {0}", user.UserId);
    }
}

//public class PlayerRegexomonManager : MonoBehaviour
//{

//    public List<Regexomon> tempList = new List<Regexomon>();

//    void Awake()
//    {
//        tempList.Clear();

//        Router.Regexomons().GetValueAsync().ContinueWith(task =>
//        {
//            DataSnapshot regexomons = task.Result;
//            foreach (DataSnapshot regexomon in regexomons.Children)
//            {
//                var regexomonDictionary = (IDictionary<string, object>)regexomon.Value;
//                Regexomon newRegexomon = new Regexomon(regexomonDictionary);
//                //logs all of the Regexomons Names
//                Debug.Log(newRegexomon.name);
//                tempList.Add(newRegexomon);
//            }
//        });
//    }
//}