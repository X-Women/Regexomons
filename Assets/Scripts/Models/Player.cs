using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {

    public string email;
    public int level;
    public int score;

    public Player(string email, int level, int score) 
    {
        this.email = email;
        this.level = level;
        this.score = score;
    }

}
