using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScriptForGameController : MonoBehaviour {

	public static ScriptForGameController Instance { get; set; }
 	public static string GameStatus;
    public Text InfoText;
    public GameObject SelectAnswer;
    public GameObject ConfirmButton;
    public GameObject FightButtons;
    public GameObject StartButtons;
    public GameObject EnemyPokemonUI;
    public GameObject SelectStartButton;
    public GameObject PikachuUI;
    public GameObject EnemyPokemonHealthBar;
    public GameObject PokeballForPikachu;
    public GameObject PikachuHealthBar;
    public GameObject Items;

    // Use this for initialization
    void Start () {
        Instance = this;
    }
    
    public void gameStatusInfoBar()
    {
        switch(GameStatus)
        { 
            case "enemyIsDead":
                InfoText.text = "REGEXIZARD is close to capturing!";
                // GameStatus = "loadLocationScene";
                // ConfirmButton.SetActive(true);
                // StartButtons.SetActive(true);
                break;

            case "loadLocationScene":
                // SceneManager.LoadScene(Scene Number)
                Debug.Log("Loading new scene!");
                break;

            case "PikachuIsDead":
                InfoText.text = "Time to brush up on your RegEX!";
                GameStatus = "loadLocationScene";
                ConfirmButton.SetActive(true);
                break;

            case "selectOption":
                InfoText.text = "";
                ConfirmButton.gameObject.SetActive(false);
                SelectAnswer.gameObject.SetActive(true);
                StartButtons.gameObject.SetActive(true);
                FightButtons.gameObject.SetActive(false);
                break;

            case "StartButtonsAppear":
                InfoText.text = "";
                SelectStartButton.gameObject.SetActive(true);
                ConfirmButton.gameObject.SetActive(false);
                FightButtons.gameObject.SetActive(false);
                StartButtons.gameObject.SetActive(true);
                break;

            case "enemyAppeared":
                InfoText.text = "I choose you! GO! REGEXACHU!";
                PikachuHealthBar.gameObject.SetActive(true);
                PikachuUI.gameObject.SetActive(true);
                 audioControl.Instance.pikachuStartSound.Play();
                PokeballForPikachu.gameObject.SetActive(false);
                ConfirmButton.SetActive(true);
                GameStatus = "StartButtonsAppear";
                break;

            case "serenaUsedPokeball":
                InfoText.text = "SERENA uses Regexball!";
                ConfirmButton.SetActive(true);
                // GameStatus = "caughtRegexmon";
                break;   

            case "caughtRegexmon":
                InfoText.text = "REGEXIZARD was caught!";
                audioControl.Instance.enemyCaughtSound.Play();
                 audioControl.Instance.fightSound.Stop();
                GameStatus = "loadLocationScene";
                break;   

            case "enemyAttacks":
                // Debug.Log("enemy attack works");
                // CharizardControlScript.Instance.Fly();
                int RandomAttack = Random.Range(0,2);
                if(RandomAttack == 0){
                    InfoText.text = "REGEXIZARD used FLY!";
                    //invoke the Fly method
                    CharizardControlScript.Instance.Fly();
                }
                else if(RandomAttack == 1 )
                {
                    InfoText.text = "REGEXIZARD used FLAMETHROWER!";
                    CharizardControlScript.Instance.Flamethrower();
                }

                // ConfirmButton.gameObject.SetActive(false);
                // SelectAnswer.gameObject.SetActive(true);
                GameStatus = "selectOption";
                break;

            case "correctAnswer":
                // InfoText.text = "PIKACHU used QUICKATTACK!";

                 int PikachuRandomAttack = Random.Range(0,2);
                if(PikachuRandomAttack == 0){
                    InfoText.text = "REGEXACHU used QUICKATTACK!";
                    //invoke the quickattack method
                    pikachuControlScript.Instance.Growl();
                }
                else if(PikachuRandomAttack == 1)
                {
                    InfoText.text = "REGEXACHU used THUNDERSHOCK!";
                     //invoke the thundershock method
                    pikachuControlScript.Instance.Thundershock();
            
                }

                GameStatus = "charizardAttacked";
                // ConfirmButton.gameObject.SetActive(true);
                break;

            case "charizardAttacked":
                InfoText.text = "REGEXIZARD's health has gone down";
                GameStatus = "selectOption";
                break;

            case "wrongAnswer":
                InfoText.text = "REGEXACHU missed QUICKATTACK!";
                GameStatus="enemyAttacks";
                break;
            
            case "fightHasStarted":
                InfoText.text = "Wild REGEXIZARD has appeared";
                EnemyPokemonUI.gameObject.SetActive(true);
                EnemyPokemonHealthBar.gameObject.SetActive(true);
                ConfirmButton.SetActive(true);
                GameStatus = "enemyAppeared";
                break;

            default:
                InfoText.text = "";
                break;
        }
    }

}
