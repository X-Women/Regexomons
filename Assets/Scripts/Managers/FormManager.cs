using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Firebase;
using Firebase.Auth;
using UnityEngine.SceneManagement;

public class FormManager : MonoBehaviour
{

    public InputField emailInput;
    public InputField passwordInput;

    public Button signUpButton;
    public Button loginButton;

    public Text statusText;

    public AuthManager authManager;

    void Awake()
    {
        ToggleButtonStates(false);

        //Delegate subsriptions
        authManager.authCallback += HandleAuthCallback;
    }
    //&& Regex.IsMatch(email, regexPattern)
    public void ValidateEmail()
    {
        string email = emailInput.text;
        var regexPattern = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
        if (email != "" && Regex.IsMatch(email, regexPattern))
        {
            ToggleButtonStates(true);
        }
        else
        {
            ToggleButtonStates(false);
        }
    }

    public void OnSignUp()
    {

        authManager.SignUpNewUser(emailInput.text, passwordInput.text);

        Debug.Log("sign up");
    }

    public void OnLogin()
    {
        authManager.LoginUser(emailInput.text, passwordInput.text);
        Debug.Log("login");
    }

    IEnumerator HandleAuthCallback(Task<Firebase.Auth.FirebaseUser> task, string operation)
    {
        if (task.IsFaulted || task.IsCanceled)
        {
            UpdateStatus("There was an error creating your account.");
        }
        else if (task.IsCompleted)
        {
            if (operation == "sign up") {
                Firebase.Auth.FirebaseUser newPlayer = task.Result;
               
                Debug.LogFormat("Welcome to Regexomon {0}!", newPlayer.Email);

                Player player = new Player(newPlayer.Email, 1, 0, "null");
                DatabaseManager.sharedInstance.CreateNewPlayer(player, newPlayer.UserId);
            }


            UpdateStatus("Game is loading...");

            yield return new WaitForSeconds(1.5f);
            //scene to change to 
            SceneManager.LoadScene("MapScene"); 
        }
    }

    //to clean up our subscribing methods, use OnDestroy
    void OnDestroy()
    {
        authManager.authCallback -= HandleAuthCallback;
    }

    private void ToggleButtonStates(bool toState)
    {

        signUpButton.interactable = toState;
        loginButton.interactable = toState;
    }

    private void UpdateStatus(string message)
    {
        statusText.text = message;
    }

}