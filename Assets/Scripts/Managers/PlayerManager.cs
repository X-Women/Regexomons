using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;

public class PlayerManager : MonoBehaviour
{

    public static List<Player> playersList = new List<Player>();
   
    void Awake()
    {
        //clears list so not duplicating data
        playersList.Clear();
        DatabaseManager.sharedInstance.GetAllPlayers(data =>
        {
            //this has the players data
            playersList = data;
            Debug.Log("PlayerList: " + playersList[0].email);


        });
       // Router.Players().ChildAdded += AddedPlayer;


    }
    //void AddedPlayer(object sender, ChildChangedEventArgs args) {
    //    if (args.Snapshot.Value == null) {
    //        Debug.Log("There is no data for that node");
    //    } else {
    //        Debug.Log("A new player has been added");
    //    }

    //}
}

