using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharizardControlScript : MonoBehaviour {

	public static CharizardControlScript Instance{set; get;}
	bool flyCharizard;
	public bool goCharizard;
	float CharizardHealth;
	// Unity variable: RegexmonEnemyHPBar
	Image HPBar; 


	// Use this for initialization
	void Start () {
		Instance = this;
		// Fly();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(GameObject.FindGameObjectWithTag("PikachuGO") != null)
		{
			transform.LookAt(GameObject.FindGameObjectWithTag("PikachuGO").transform.position);
		}

		if(flyCharizard)
		{
			transform.Translate(Vector3.up * Time.deltaTime * 6f);
		}
		
		if(goCharizard)
		{
			transform.Translate(Vector3.forward * Time.deltaTime * 5f);
		}
	}

	public void Fly()
		{
			flyCharizard = true;
			StartCoroutine(waitForFlyAttack());
		}

		IEnumerator waitForFlyAttack()
		{
			yield return new WaitForSeconds(1.5f);
			flyCharizard = false;
			yield return new WaitForSeconds(0.5f);
			goCharizard = true;
			gameObject.GetComponent<Animator>().Play("flyAttack");
		}
	
	public void quickAttackFromPikachu(float quickAttackValue, bool collisionWPikachu)
	{
		HPBar = GameObject.Find("backgroundColor").GetComponent<Image>();
		CharizardHealth -= quickAttackValue;

		if(collisionWPikachu)
		{
			HPBar.fillAmount = CharizardHealth / 100f;
		}
	}

}
