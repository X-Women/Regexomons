using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;


public class RegexomonManager : MonoBehaviour
{

    public List<Regexomon> tempList = new List<Regexomon>();

    void Awake()
    {
        tempList.Clear();
        Router.Regexomons().GetValueAsync().ContinueWith(task =>
        {
            DataSnapshot regexomons = task.Result;
            foreach (DataSnapshot regexomon in regexomons.Children)
            {
                var regexomonDictionary = (IDictionary<string, object>)regexomon.Value;
                Regexomon newRegexomon = new Regexomon(regexomonDictionary);
                //logs all of the Regexomons Names
                Debug.Log(newRegexomon.name);
                tempList.Add(newRegexomon);
            }
        });
    }
}


//public class PlayerManager : MonoBehaviour
//{

//    public List<Player> playersList = new List<Player>();

//    void Awake()
//    {
//        ////clears list so not duplicating data
//        //playersList.Clear();
//        //DatabaseManager.sharedInstance.GetAllPlayers(data =>
//        //{
//        //    //this has the players data
//        //    playersList = data;
//        //    Debug.Log("PlayerList: " + playersList[0].email);


//        //});
//        //Router.Players().ChildAdded += AddedPlayer;


//    }
//    //void AddedPlayer(object sender, ChildChangedEventArgs args) {
//    //    if (args.Snapshot.Value == null) {
//    //        Debug.Log("There is no data for that node");
//    //    } else {
//    //        Debug.Log("A new player has been added");
//    //    }

//    //}
//}
