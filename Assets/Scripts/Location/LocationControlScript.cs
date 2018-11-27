using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LocationControlScript : MonoBehaviour {

	public GameObject[] Regexomons;
	GameObject randomRegexomonGO;
	public Transform Trainer;
	public Transform Map;
	int randomRegexomon;
	int randomX;


	// Use this for initialization
	void Start () {
		
		MyRandomRegexomon();
	}

	void MyRandomRegexomon()
	{
		randomRegexomon = Random.Range(0, Regexomons.Length+1);
		randomX = Random.Range(-20, 20);
		randomRegexomonGO = Instantiate (Regexomons[randomRegexomon], new Vector3(randomX, Map.position.y, Map.position.z), Quaternion.identity) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {

		float distance = Vector3.Distance(randomRegexomonGO.transform.position, Trainer.position);
        print(distance);

		 if(distance <=5f && randomRegexomonGO.tag == "randomCharizard" )
        {
            SceneManager.LoadScene("FightScene");
        }
		
        if (distance <= 5f && randomRegexomonGO.tag == "randomSquirtle")
        {
            Debug.Log("loadSceneForRandomSquirtle");
        }
	}
}
