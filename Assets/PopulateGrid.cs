using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Auth;

public class PopulateGrid : MonoBehaviour 
{
	public GameObject prefabRegexomon; //this is our prefab object that will be exposed in the inspector
    public GameObject scrollContainer;                                 //public GameObject scrollContainer;


    //public int numberToCreate = ManageUserId.CurrentUserId.Length; //number of objects to create.exposed in inspector

    public List<PlayerRegexomon> regexomonList = new List<PlayerRegexomon>();

    //void Populate()
    void Awake()
	{
        regexomonList.Clear();

        var CurrentUserId = UserIdManager.CurrentUserId;
        GameObject newObj; //Create Game object instance
        newObj = (GameObject)Instantiate(prefabRegexomon, transform);

        Router.PlayerWithUID(CurrentUserId).Child("regexomon").GetValueAsync().ContinueWith(task =>
        {
            DataSnapshot regexomons = task.Result;
            foreach (DataSnapshot regexomon in regexomons.Children)
            {
                newObj = (GameObject)Instantiate(prefabRegexomon, transform);
                var regDictionary = (IDictionary<string, object>)regexomon.Value;
                PlayerRegexomon newPlayerRegexomon = new PlayerRegexomon(regDictionary);
                Debug.Log("DID I DO IT?" + newPlayerRegexomon.name);
                regexomonList.Add(newPlayerRegexomon);
            }

        });
        InitialiseUI();

    }

    void InitialiseUI() {
        foreach (PlayerRegexomon regexomon in regexomonList) 
        {
            CreateRow(regexomon);
        }
    }

    void CreateRow(PlayerRegexomon regexomon)
    {
        GameObject newReg = Instantiate(prefabRegexomon) as GameObject;
        newReg.transform.SetParent(scrollContainer.transform, false);
    }
    
}
