using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Auth;

public class PopulateGrid : MonoBehaviour 
{
	public GameObject prefabRegexomon;
    public GameObject scrollContainer;                                
    public List<PlayerRegexomon> regList;

    void Awake()
	{
        regList = UserRegManager.regexomonList;
        InitialiseUI();

    }

    void InitialiseUI() {
        foreach (PlayerRegexomon regexomon in regList) 
        {
            CreateRow(regexomon);
        }
    }

    void CreateRow(PlayerRegexomon regexomon)
    {
        GameObject newReg = Instantiate(prefabRegexomon) as GameObject;
        newReg.GetComponent<RegexomonConfig>().Initialize(regexomon);
        newReg.transform.SetParent(scrollContainer.transform, false);
    }
    void Update()
    {
        regList = UserRegManager.regexomonList;
        InitialiseUI();
    }

}
