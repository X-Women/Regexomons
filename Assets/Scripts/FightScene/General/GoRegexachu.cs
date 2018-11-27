using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoRegexachu : MonoBehaviour {

	public GameObject Pikachu;
	public GameObject Pokeball;

	public void goPikachu()
	{
		StartCoroutine(spawnPikachu());
	}

	IEnumerator spawnPikachu()
	{
		Pokeball.gameObject.SetActive(true);
		Pokeball.GetComponent<Animator>().Play("goPikachu");
		yield return new WaitForSeconds(1.5f);

		ScriptForGameController.GameStatus = "pokemonIsOut";
		ScriptForGameController.Instance.gameStatusInfoBar();

		Pikachu.gameObject.SetActive(true);
		Pokeball.GetComponent<Animator>().enabled = false;
		Pokeball.gameObject.SetActive(false);
	}
}
