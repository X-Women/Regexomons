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
            levelOneQuestions.Clear();
            DataSnapshot questions = task.Result;
            foreach (DataSnapshot quest in questions.Children)
            {
                var questionDictionary = (IDictionary<string, object>)quest.Value;
                QuestionSet newQuestion = new QuestionSet(questionDictionary);
                //Debug.Log("newQuestion.question " + newQuestion.question);
                levelOneQuestions.Add(newQuestion);
            }
            //Debug.Log("What is the length?: " + levelOneQuestions.Count);
            //Debug.Log("What is at index 0: " + levelOneQuestions[0].question);
        });

    }

}