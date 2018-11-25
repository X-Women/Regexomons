using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;


public class QuestionManager : MonoBehaviour
{

    public List<QuestionSet> questionsList = new List<QuestionSet>();

    void Awake()
    {   
        //This gives access to the Level1 Questions

        Router.QuestionsLevelOne().GetValueAsync().ContinueWith(task =>
        {
            DataSnapshot questions = task.Result;
            foreach (DataSnapshot question in questions.Children)
            {
                var questionDictionary = (IDictionary<string, object>)question.Value;
                QuestionSet newQuestion = new QuestionSet(questionDictionary);
                //logs all of the questionSet questions 
                Debug.Log(newQuestion.question);
                questionsList.Add(newQuestion);
            }
        });
    }
}
