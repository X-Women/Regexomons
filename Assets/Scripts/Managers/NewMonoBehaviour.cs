using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Auth;


public class ManageUserId : MonoBehaviour
{
    public static string CurrentUserId = FirebaseAuth.DefaultInstance.CurrentUser.UserId;
 
}
