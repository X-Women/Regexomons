using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pikachuControlScript : MonoBehaviour {

	public static pikachuControlScript Instance {set; get;}
	public bool pikachuMove;
	public float quickAttackValue = 20;

	// Use this for initialization
	void Start () {
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(GameObject.FindGameObjectWithTag("CharizardGO") != null)
		{
			transform.LookAt(GameObject.FindGameObjectWithTag("CharizardGO").transform.position);
			transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
		}

		if(pikachuMove)
		{
			transform.Translate(Vector3.forward * Time.deltaTime * 3f);
		}
 	}

	 public void Growl()
	 {
		 CharizardControlScript.Instance.quickAttackFromPikachu(quickAttackValue, false);
		 gameObject.GetComponent<Animator>().Play("Attack");
		 pikachuMove = true;
		 ScriptForGameController.GameStatus = "correctAnswer";
		 ScriptForGameController.Instance.gameStatusInfoBar();
	 }

	 public void Missed()
	 {
		 gameObject.GetComponent<Animator>().Play("Attack");
		 pikachuMove = false ;
		 ScriptForGameController.GameStatus = "wrongAnswer";
		ScriptForGameController.Instance.SelectAnswer.SetActive(false);
		ScriptForGameController.Instance.ConfirmButton.SetActive(true);
		 ScriptForGameController.Instance.gameStatusInfoBar(); 
	 }
}
