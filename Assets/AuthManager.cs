using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FireBase;
using FireBase.Auth;

public class AuthManager : MonoBehaviour {

    //Firerbase API varibles

    Firebase.Auth.FirebaseAuth auth;
	// Use this for initialization
    void Await () {
        auth = FirebaseAuth.DefaultInstance;
    }

    public void SignUpNewUser(string email, string password) {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsFaulted || task.IsCanceled) {
                Debug.LogError("Sorry, here was an error creating your account. ERROR: " + task.Exception);
                return;
            } else if (task.IsCompleted) {
                Firebase.Auth.FirebaseUser newPlayer = task.Result;
                Debug.LogFormat("Welcome to FireQuest {0}", newPlayer.Email);
            }
        });
    }

}
