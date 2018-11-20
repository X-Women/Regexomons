using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptForGameController : MonoBehaviour {

	public static ScriptForGameController Instance { get; set; }
 	public static string GameStatus;
    public Text InfoText;
    public GameObject SelectAnswer;
    public GameObject ConfirmButton;
    public GameObject FightButtons;
    public GameObject StartButtons;

    // Use this for initialization
    void Start () {
        Instance = this;
    }
    
    public void gameStatusInfoBar()
    {
        switch(GameStatus)
        { 
            case "selectOption":
                InfoText.text = "";
                ConfirmButton.gameObject.SetActive(false);
                SelectAnswer.gameObject.SetActive(true);
                StartButtons.gameObject.SetActive(true);
                FightButtons.gameObject.SetActive(false);
                break;

            case "enemyAppeared":
                InfoText.text = "GO! PIKACHU!";
                break;

            case "ashUsedPokeball":
                InfoText.text = "ASH uses Pokeball!";
                break;   

            case "caughtRegexmon":
                InfoText.text = "CHARIZARD was caught!";
                break;   

            case "enemyAttacks":
                // Debug.Log("enemy attack works");
                // CharizardControlScript.Instance.Fly();
                int RandomAttack = Random.Range(0,1);
                if(RandomAttack == 0){
                    InfoText.text = "CHARIZARD used FLY!";
                    //invoke the Fly method
                    CharizardControlScript.Instance.Fly();
                }
                else if(RandomAttack == 1)
                {
                    InfoText.text = "CHARIZARD used FLAMETHROWER!";
                    //invoke the flamethrower method
                }

                // ConfirmButton.gameObject.SetActive(false);
                // SelectAnswer.gameObject.SetActive(true);
                GameStatus = "selectOption";
                break;

            case "correctAnswer":
                InfoText.text = "PIKACHU used QUICKATTACK!";
                break;

            case "wrongAnswer":
                InfoText.text = "PIKACHU missed QUICKATTACK!";
                GameStatus="enemyAttacks";
                break;
            
            case "fightHasStarted":
                InfoText.text = "Wild CHARIZARD has appeared";
                break;

            default:
                InfoText.text = "";
                break;
        }
    }

}
