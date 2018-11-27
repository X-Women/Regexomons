using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using System.Threading.Tasks;

public class UserIdManager : MonoBehaviour {
    public static string CurrentUserId = FirebaseAuth.DefaultInstance.CurrentUser.UserId;
    void Start () {
		
	}
}
