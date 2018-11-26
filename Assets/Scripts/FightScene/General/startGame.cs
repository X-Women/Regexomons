using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class startGame : MonoBehaviour {

	public Image BlackScreen;
	float fillAmount;
	// Use this for initialization
	void Start () {
		StartCoroutine(StartFight());
	}
	
	IEnumerator StartFight()
	{
		BlackScreen.gameObject.SetActive(true);
		//play sound effect
		yield return new WaitForSeconds(0.1f);
		for (int i=0; i<=20; i++)
		{
			float randomAlpha = Random.Range(0.0f, 1.2f);
			yield return new WaitForSeconds (0.05f);
			BlackScreen.color = new Color (0f, 0f, 0f, randomAlpha);
		}   
		BlackScreen.color = new Color (0f, 0f, 0f, 1.0f);
		BlackScreen.fillAmount = 0f;

		while (fillAmount <= 1)
		{
			yield return new WaitForSeconds(0.03f);
			fillAmount += 0.05f;
			BlackScreen.fillAmount = fillAmount;


		}

		for (int i=0; i<=20; i++)
		{
			yield return new WaitForSeconds (0.05f);
			BlackScreen.color = new Color (0f, 0f, 0f, 1f);
			yield return new WaitForSeconds (0.05f);
			BlackScreen.color = new Color (0f, 0f, 0f, 0f);
		}   

		ScriptForGameController.GameStatus = "fightHasStarted";
		ScriptForGameController.Instance.gameStatusInfoBar();
		// CharizardControlScript.Instance.charizardAppeared();
		BlackScreen.gameObject.SetActive(false);

	}
}
