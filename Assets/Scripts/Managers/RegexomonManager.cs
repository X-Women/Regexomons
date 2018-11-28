using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;


public class RegexomonManager : MonoBehaviour
{

    public List<Regexomon> tempList = new List<Regexomon>();

    void Awake()
    {
        tempList.Clear();
        Router.Regexomons().GetValueAsync().ContinueWith(task =>
        {
            DataSnapshot regexomons = task.Result;
            foreach (DataSnapshot regexomon in regexomons.Children)
            {
                var regexomonDictionary = (IDictionary<string, object>)regexomon.Value;
                Regexomon newRegexomon = new Regexomon(regexomonDictionary);
                //logs all of the Regexomons Names
                Debug.Log(newRegexomon.name);
            }
        });
    }
}


