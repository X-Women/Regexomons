using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using System.Threading.Tasks;

public class AuthManager : MonoBehaviour
{

    //Firerbase API varibles

    Firebase.Auth.FirebaseAuth auth;


    //Delegates
    public delegate IEnumerator AuthCallback(Task<Firebase.Auth.FirebaseUser> task, string operation);
    public event AuthCallback authCallback;



    // Use this for initialization
    void Awake()
    {
        auth = FirebaseAuth.DefaultInstance;
    }

    //Creates new account in the database
    public void SignUpNewUser(string email, string password)
    {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            StartCoroutine(authCallback(task, "sign up"));
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.LogError("There was an error creating your account. ERROR: " + task.Exception);
                return;
            }
            else if (task.IsCompleted)
            {
                Firebase.Auth.FirebaseUser newPlayer = task.Result;
                Debug.LogFormat("Welcome to Regexomon {0}", newPlayer.Email);
            }
        });
    }

}