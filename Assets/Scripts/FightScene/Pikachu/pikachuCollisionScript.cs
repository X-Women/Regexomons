using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pikachuCollisionScript : MonoBehaviour {

	// Use this for initialization
	void OnCollisionEnter (Collision Col)
	{
		 
		if(Col.gameObject.tag == "charizardCollision")
		{
			pikachuControlScript.Instance.pikachuMove = false;
			// returns pikachu back to his position
			GameObject.Find("Pikachu").transform.position = GameObject.Find ("MyRegexmon").transform.position;
			// pikachu starts to bop again
			GameObject.Find("Pikachu").GetComponent<Animator>().Play("pikachuIDLE");
			// Charizard should animate in attacked position
			// GameObject.FindGameObjectWithTag("CharizardGO").GetComponent<Animator>().Play("collisionWPikachu");
			// ScriptForGameController.Instance.SelectAnswer.SetActive(false);
			// ScriptForGameController.Instance.ConfirmButton.SetActive(true);
			GameObject.FindGameObjectWithTag("CharizardGO").GetComponent<Animator>().Play("collisionWPikachu");

			// GameObject.Find("Charizard").GetComponent<Animator>().Play("collisionWPikachu");
			// put some sound
			// health bar needs to decrease
		}
	}
}
