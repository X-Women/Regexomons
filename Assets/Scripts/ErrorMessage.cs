using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorMessage : MonoBehaviour {

    public static string errorMessgae = " ";

    public Text message;

    // Use this for initialization
    void Start () {
        message = GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update () {
        message.text = errorMessgae;
    }
}
