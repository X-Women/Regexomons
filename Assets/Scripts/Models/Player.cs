using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    public Player(string email, int level, int score, string regexomon) 
    {
        this.email = email;
        this.level = level;
        this.score = score;
        this.regexomon = regexomon;
    }

}
