using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerRegexomon
{
    public string name;
    public string imageUrl;
    public string question;
    public string answer;

    public PlayerRegexomon(string name, string imageUrl, string question, string answer)
    {
        this.name = name;
        this.imageUrl = imageUrl;
        this.question = question;
        this.answer = answer;

    }


    public PlayerRegexomon(IDictionary<string, object> dictionary)
    {
        this.name = dictionary["name"].ToString();
        this.imageUrl = dictionary["imageUrl"].ToString();
        this.question = dictionary["question"].ToString();
        this.answer = dictionary["answer"].ToString();
    }
}
