using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player {

    public string email;
    public int level;
    public int score;
    public string regexomon;


    //default constructors

    //public Player() {
    //    this.level = 1;
    //    this.score = 0;
    //    this.regexomon = "null";
    //}


    public Player(string email, int score, int level, string regexomon) 
    {
        this.email = email;
        this.score = score;
        this.level = level;
        this.regexomon = regexomon;
    }

    public Player(IDictionary<string, object> dict) {
        this.email = dict["email"].ToString();
        this.score = Convert.ToInt32(dict["score"]);
        this.level = Convert.ToInt32(dict["level"]);
        this.regexomon = dict["regexomon"].ToString();
    }

}
