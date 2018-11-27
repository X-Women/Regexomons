using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pikachuControlScript : MonoBehaviour {

	public static pikachuControlScript Instance {set; get;}
	public bool pikachuMove;
	public float quickAttackValue = 40f;
	public float thunderShockValue = 50f;
	public ParticleSystem Sparks;
	public GameObject LightningBolt;
	public float PikachuHealth = 100f;

	Image HPBar;


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

		if(PikachuHealth <= 0)
		{
			StartCoroutine(waitThenDead());
		}
 	}

	 public void Growl()
	 {
		 CharizardControlScript.Instance.quickAttackFromPikachu(quickAttackValue, false);
		 gameObject.GetComponent<Animator>().Play("Attack");
		 pikachuMove = true;
		 ScriptForGameController.GameStatus = "correctAnswer";
		 ScriptForGameController.Instance.SelectAnswer.SetActive(false);
		 ScriptForGameController.Instance.ConfirmButton.SetActive(true);
		 ScriptForGameController.Instance.gameStatusInfoBar();
	 }

	 public void Thundershock()
	 {
		 CharizardControlScript.Instance.quickAttackFromPikachu(quickAttackValue, false);
		//  gameObject.GetComponent<Animator>().Play("electro");
		//  pikachuMove = true;
		 ScriptForGameController.GameStatus = "correctAnswer";
		//  ScriptForGameController.Instance.SelectAnswer.SetActive(false);
		//  ScriptForGameController.Instance.ConfirmButton.SetActive(true);
		//  ScriptForGameController.Instance.gameStatusInfoBar();
		 StartCoroutine(ThundershockCoroutine());
	 }

	 IEnumerator ThundershockCoroutine()
	 {
		 gameObject.GetComponent<Animator>().Play("electro");
		 yield return new WaitForSeconds (0.5f);
		 Sparks.Play();
		 yield return new WaitForSeconds (0.5f);
		audioControl.Instance.thundershockSound.Play();	
		 LightningBolt.gameObject.SetActive(true);
		 CharizardControlScript.Instance.thunderShockFromPikachu(thunderShockValue);
		GameObject.FindGameObjectWithTag("CharizardGO").GetComponent<Animator>().Play("collisionWPikachu");
		 yield return new WaitForSeconds (1f);
		 LightningBolt.gameObject.SetActive(false);
		 Sparks.Stop();
		 GameObject.Find("Pikachu").transform.position = GameObject.Find ("IdlePikachu").transform.position;
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

	public void flyAttackFromCharizard(float flyAttackValue, bool collisionWithCharizard)
	{
		HPBar = GameObject.Find("RegexachuHealthColor").GetComponent<Image>();
		PikachuHealth -= flyAttackValue;

		if(collisionWithCharizard)
		{
			HPBar.fillAmount = PikachuHealth / 150f;
			// HPBar.fillAmount -= 35f;
		
		}
	}

	public void flamethrowerFromCharizard (float flameAttackValue)
	{
		HPBar = GameObject.Find("RegexachuHealthColor").GetComponent<Image>();
		PikachuHealth -= flameAttackValue;
		HPBar.fillAmount = PikachuHealth / 150f;
	}

	IEnumerator waitThenDead()
	{
		yield return new WaitForSeconds (2.5f);
		ScriptForGameController.GameStatus = "PikachuIsDead";
		ScriptForGameController.Instance.gameStatusInfoBar();
		// gameObject.SetActive(false);

	}

}
