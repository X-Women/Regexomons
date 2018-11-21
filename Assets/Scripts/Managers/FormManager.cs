using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Text.RegularExpressions;

public class FormManager : MonoBehaviour {

  public InputField emailInput;
  public InputField passwordInput;

  public Button signUpButton;
  public Button loginButton;

  public Text statusText;

  public AuthManager authManager;

  void Awake () {
        ToggleButtonStates(false);
  }
    //&& Regex.IsMatch(email, regexPattern)
    public void ValidateEmail() {
        string email = emailInput.text;
        var regexPattern = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
        Debug.Log("HelloBethany");
        if (email != "" ) {
            Debug.Log("HelloWorld");
        ToggleButtonStates (true);
      } else {
        ToggleButtonStates(false);
      }
  }

  public void OnSignUp () {
        Debug.Log("HELLO CLASS");
        authManager.SignUpNewUser (emailInput.text, passwordInput.text);

    Debug.Log("sign up");
  }

  public void OnLogin () {
    Debug.Log("login");
  }


  private void ToggleButtonStates(bool toState) {

    signUpButton.interactable = toState;
    loginButton.interactable = toState;
  }

  private void UpdateStatus(string message) {
    statusText.text = message;
  }

}
