using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoPokeball : MonoBehaviour {

	public GameObject Pokeball;
	bool ballMove;
	// Update is called once per frame
	void Update () {

		if(GameObject.FindGameObjectWithTag("CharizardGO") != null)
		{
			Pokeball.transform.LookAt(GameObject.FindGameObjectWithTag("CharizardGO").transform.position);
		}

		if (ballMove)
		{
			Pokeball.transform.Translate(Vector3.forward * Time.deltaTime * 25f);
		}
	}

	public void catchEnemy()
	{
		ScriptForGameController.GameStatus = "serenaUsedPokeball";
		ScriptForGameController.Instance.gameStatusInfoBar();
		ScriptForGameController.Instance.Items.gameObject.SetActive(false);
		// ScriptForGameController.Instance.StartButtons.gameObject.SetActive(true);
		StartCoroutine(waitCharizardInBall());

		Pokeball.gameObject.SetActive(true);
		ballMove = true;
	}

	IEnumerator waitCharizardInBall()
	{
		yield return new WaitForSeconds(2f);
		GameObject.FindGameObjectWithTag("CharizardGO").SetActive(false);
		 audioControl.Instance.enemyInPokeballSound.Play();
		ScriptForGameController.GameStatus = "caughtRegexmon";
		ScriptForGameController.Instance.ConfirmButton.SetActive(true);
	}
}
