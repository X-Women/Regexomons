using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharizardControlScript : MonoBehaviour {

	public static CharizardControlScript Instance{set; get;}
	bool flyCharizard;
	public bool goCharizard;
	float CharizardHealth = 100f;
	public ParticleSystem FlameThrowerGO;
	public float flyAttackValue = 20f;
	public float flameThrowerValue = 30;
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
			transform.Translate(Vector3.up * Time.deltaTime * 2f);
		}
		
		if(goCharizard)
		{
			transform.Translate(Vector3.forward * Time.deltaTime * 5f);
		}

		if(CharizardHealth <= 0)
		{
			StartCoroutine(waitThenDead());
		}
	}

	public void charizardAppeared()
	{
		//sound for charizard
		
	}


	public void Fly()
		{
			flyCharizard = true;
			StartCoroutine(waitForFlyAttack());
			pikachuControlScript.Instance.flyAttackFromCharizard(flyAttackValue, false);
		}

		IEnumerator waitForFlyAttack()
		{
			yield return new WaitForSeconds(1.5f);
			flyCharizard = false;
			yield return new WaitForSeconds(0.5f);
			goCharizard = true;
			gameObject.GetComponent<Animator>().Play("flyAttack");
		}

	 public void Flamethrower()
    {
        StartCoroutine(waitForFlameThrower());
    }

    IEnumerator waitForFlameThrower()
    {
        gameObject.GetComponent<Animator>().Play("flamethrower");
        yield return new WaitForSeconds(1f);
        FlameThrowerGO.Play();
        // play sound
        yield return new WaitForSeconds(0.5f);
		pikachuControlScript.Instance.flamethrowerFromCharizard(flameThrowerValue);
        GameObject.Find("Pikachu").GetComponent<Animator>().Play("attackFromCharizard");
        yield return new WaitForSeconds(1.2f);
        FlameThrowerGO.Stop();
        ScriptForGameController.Instance.ConfirmButton.SetActive(true);
    }
	
	public void quickAttackFromPikachu(float quickAttackValue, bool collisionWPikachu)
	{
		HPBar = GameObject.Find("EnemyHPColor").GetComponent<Image>();
		CharizardHealth -= quickAttackValue;

		if(collisionWPikachu)
		{
			HPBar.fillAmount = CharizardHealth / 150f;
			// HPBar.fillAmount -= 35f;
		
		}
	}

	 public void thunderShockFromPikachu(float thunderShockValue)
    {
        HPBar = GameObject.Find("EnemyHPColor").GetComponent<Image>();
        CharizardHealth -= thunderShockValue;
        HPBar.fillAmount = CharizardHealth / 100f;
    }

	IEnumerator waitThenDead()
	{
		yield return new WaitForSeconds (2.5f);
		ScriptForGameController.GameStatus = "enemyIsDead";
		ScriptForGameController.Instance.gameStatusInfoBar();
		// gameObject.SetActive(false);
	}

}
