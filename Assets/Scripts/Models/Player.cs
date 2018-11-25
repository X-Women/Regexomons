using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{

    public string email;
    public int level;
    public int score;
    public string regexomon;


    public Player(string email, int level, int score, string regexomon)
    {
        this.email = email;
        this.level = level;
        this.score = score;
        this.regexomon = regexomon;
    }

    public Player(IDictionary<string, object> dictionary)
    {
        this.email = dictionary["email"].ToString();
        this.level = Convert.ToInt32(dictionary["level"]);
        this.score = Convert.ToInt32(dictionary["score"]);
        //change this later
        this.regexomon = dictionary["regexomon"].ToString();
    }

}
