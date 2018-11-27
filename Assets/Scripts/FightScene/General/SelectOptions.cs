using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectOptions : MonoBehaviour {

	public GameObject StartButtons;
    public GameObject FightButtons;
    public GameObject Items;
    public GameObject Question;
	
    public void onFight()
    {
        StartButtons.gameObject.SetActive(false);
        FightButtons.gameObject.SetActive(true);
        Question.gameObject.SetActive(true);

    }

    public void onItem()
    {
        StartButtons.gameObject.SetActive(false);
        Items.gameObject.SetActive(true);
    }

    public void onEmpty()
    {
        // for example open new UI for Pokemons
    }

    public void onRun()
    {
        // for example load locationBased Scene
    }

}
