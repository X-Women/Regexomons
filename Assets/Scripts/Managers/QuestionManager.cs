using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;


public class QuestionManager : MonoBehaviour
{
    //This gives access to the Level1 Questions
    public static List<QuestionSet> levelOneQuestions = new List<QuestionSet>();

    void Awake()
    {    
        Router.GetLevelOneQuestions().GetValueAsync().ContinueWith(task =>
        {
            DataSnapshot questions = task.Result;
            foreach (DataSnapshot quest in questions.Children)
            {
                var questionDictionary = (IDictionary<string, object>)quest.Value;
                QuestionSet newQuestion = new QuestionSet(questionDictionary);
                levelOneQuestions.Add(newQuestion);
            }
        });

    }

}
