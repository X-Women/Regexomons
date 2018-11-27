using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionWithPokeball : MonoBehaviour {
 
	private void OnCollisionEnter(Collision Col)
	{
		if(Col.gameObject.tag == "charizardCollision")
		{
			GameObject.FindGameObjectWithTag("CharizardGO").SetActive(false);
			gameObject.GetComponent<Animator>().enabled = true;
			gameObject.GetComponent<Animator>().Play("enemyInBall");
			//play sound
			StartCoroutine(waitCharizardInBall());
		}
	}

	IEnumerator waitCharizardInBall()
	{
		yield return new WaitForSeconds(2f);
		ScriptForGameController.GameStatus = "caughtRegexmon";
		ScriptForGameController.Instance.ConfirmButton.SetActive(true);
	}

}
