using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateGrid : MonoBehaviour 
{
	public GameObject prefab; //this is our prefab object that will be exposed in the inspector

	public int numberToCreate; //number of objects to create.exposed in inspector

	void Start () 
	{
		Populate();
	}
	

	void Update () 
	{
		
	}

	void Populate()
	{
		GameObject newObj; //Create Game object instance

		for(int i = 0; i < numberToCreate; i++)
		{
			newObj = (GameObject)Instantiate(prefab, transform); //Create new instances of our prefab until we've created as many as we specified
			newObj.GetComponent<Image>().color = Random.ColorHSV(); // Randomize the color of our image
		}
	}
}
