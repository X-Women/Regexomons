using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QuestionSet
{

    public string question;
    public string match;
    public bool caseSensitive;
    public string right;
    public List<string> wrong;
    //public int points;


    public QuestionSet(string question, string match, bool caseSensitive, string right, List<string> wrong, int points)
    {
        this.question = question;
        this.match = match;
        this.caseSensitive = caseSensitive;
        this.right = right;
        this.wrong = wrong;
        //this.points = points;
    }

    public QuestionSet(IDictionary<string, object> dictionary)
    {
        try {
            this.question = dictionary["Question"].ToString();
            this.match = dictionary["Match"].ToString();
            this.caseSensitive = Convert.ToBoolean(dictionary["CaseSensitive"]);
            this.right = dictionary["Right"].ToString();

            var tempWrong = dictionary["Wrong"];
            Debug.Log("Type: " + tempWrong.GetType().FullName);
            var objList = ((List<object>)tempWrong);
            var list = new List<string>();
            foreach(var x in objList) 
            {
                list.Add(x.ToString());
            }
            this.wrong = list;
            //this.points = points;
        }
        catch (Exception ex) {
            Debug.Log(ex);
        }
    }

}