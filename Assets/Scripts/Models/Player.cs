using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Player
{

    public string email;
    public int level;
    public int score;
    //public List<PlayerRegexomon> regexomon;


    public Player(string email, int level, int score, List<PlayerRegexomon> regexomon)
    {
        this.email = email;
        this.level = level;
        this.score = score;
        //this.regexomon = regexomon;

    }

    public Player(IDictionary<string, object> dictionary)
    {
        Debug.Log("Is this running?");
        try
        {
            this.email = dictionary["email"].ToString();
            this.level = Convert.ToInt32(dictionary["level"]);
            this.score = Convert.ToInt32(dictionary["score"]);

            Debug.Log("this.email" + this.email);
            Debug.Log("this.level" + this.level);
            Debug.Log("this.score" + this.score);
            //regexomon list being created below

            //var tempReqexomon = dictionary["regexomon"];
            //var regexomonObjList = ((List<object>)tempReqexomon);
            //var list = new List<PlayerRegexomon>();
            //foreach (var x in regexomonObjList)
            //{
            //    list.Add((PlayerRegexomon)x);
            //}
            //this.regexomon = list;
           
            //Debug.Log("this.regexomon" + this.regexomon[0]);

            //this.regexomon = dictionary["regexomon"].ToString();
        } catch(Exception ex) 
        {
            Debug.Log(ex);
        }

    }

}






//public Player(IDictionary<string, object> dictionary)
//{
//    try
//    {
//        this.email = dictionary["email"].ToString();
//        this.level = Convert.ToInt32(dictionary["level"]);
//        this.score = Convert.ToInt32(dictionary["score"]);
//        //regexomon list being created below

//        var tempReqexomon = dictionary["regexomon"];
//        var regexomonObjList = ((List<object>)tempReqexomon);
//        var list = new List<string>();
//        foreach (var x in regexomonObjList)
//        {
//            list.Add(x.ToString());
//        }
//        this.regexomon = list;


//        //this.regexomon = dictionary["regexomon"].ToString();
//    }
//    catch (Exception ex)
//    {
//        Debug.Log(ex);
//    }

//}
