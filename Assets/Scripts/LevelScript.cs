using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour {

    public static int levelValue = 1;
    Text level;

    // Use this for initialization
    void Start()
    {
        level = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        level.text = "Level: " + levelValue;
    }
}


