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
        var regexPattern = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-0-9a-zA-Z]*[0-9a-zA-Z]*\.)+[A-Za-z0-9][\-a-zA-Z0-9]{0,22}[a-zA-Z0-9]))$";
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
        Debug.Log(emailInput.text);
    }

    IEnumerator HandleAuthCallback(Task<Firebase.Auth.FirebaseUser> task, string operation)
    {
        if (task.IsFaulted || task.IsCanceled)
        {
            Debug.Log("error");

            ErrorMessage.errorMessgae = "Oh no! There was an error with your account! Please SIGN UP or use a valid email. ";
            UpdateStatus("There was an error creating your account.");
         
        }
        else if (task.IsCompleted)
        {
            if (operation == "sign up")
            {
                Firebase.Auth.FirebaseUser newPlayer = task.Result;

                Debug.LogFormat("Welcome to Regexomon {0}!", newPlayer.Email);

                PlayerRegexomon initialRegexomon = new PlayerRegexomon("Regapikachu", "https://i.ibb.co/wyPDL2P/Regapikachu.png", "no question", "no answer");

                Player player = new Player(newPlayer.Email, 1, 0, new List<PlayerRegexomon> { initialRegexomon });
                DatabaseManager.sharedInstance.CreateNewPlayer(player, newPlayer.UserId);

                //To get better key, impliment below, but right now it breakes

                //string playerJSON = JsonUtility.ToJson(initialRegexomon);
                //Player player = new Player(newPlayer.Email, 1, 0, new List<PlayerRegexomon> { });
                //DatabaseManager.sharedInstance.CreateNewPlayer(player, newPlayer.UserId);
                //string key = Router.PlayerWithUID(newPlayer.UserId).Child("regexomon").Push().Key; //this will create a key
                //Router.PlayerWithUID(newPlayer.UserId).Child("regexomon").Child(key).SetRawJsonValueAsync(playerJSON);

            }

            if (operation == "login") {
                Debug.Log("email found");
            }

            UpdateStatus("Game is loading...");

            yield return new WaitForSeconds(1.5f);
            //scene to change to 
            SceneManager.LoadScene("MainScene"); 
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