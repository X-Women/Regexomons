using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using UnityEngine.UI;
using UnityEngine;
public class QuestionSets {
    public string Question { get; set; }
    public string[] Wrong { get; set; }
    public string Right { get; set; }
}

public class buttonScript : MonoBehaviour {

    public static buttonScript Instance {set; get;}
    public GameObject QuestionForBattle;

    public static void Shuffle(string[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Swap(array, i, Random.Range(0, array.Length));
        }
    }
    public static void Swap(string[] array2, int a, int b)
    {
        string temp = array2[a];
        array2[a] = array2[b];
        array2[b] = temp;
    }
    static string[] buttons = { "Option1", "Option2", "Option3", "Option4" };

    
    //  QuestionSet question = questions[Random.Range(0, questions.Length)];
    

    // QuestionSets firstQuestion = new QuestionSets { Question = "What ’t’ will this find?: /t$/ ", Wrong = new string[] { "\"the\"", "\"better\"", "\"tea\""}, Right = "\"eat\""  };
    // Use this for initialization
     void Start () {
        Instance = this;
        List <QuestionSet> questions = QuestionManager.levelOneQuestions;
        QuestionSet firstQuestion = questions[Random.Range(0, questions.Count)];
        QuestionForBattle.gameObject.SetActive(true);
        // GameObject.Find("Question1")
        QuestionForBattle.GetComponentInChildren<Text>().text = firstQuestion.question;
        Shuffle(buttons);
        GameObject.Find(buttons[0]).GetComponentInChildren<Text>().text = firstQuestion.wrong[0];
        GameObject.Find(buttons[1]).GetComponentInChildren<Text>().text = firstQuestion.wrong[1];
        GameObject.Find(buttons[2]).GetComponentInChildren<Text>().text = firstQuestion.wrong[2];
        GameObject.Find(buttons[3]).GetComponentInChildren<Text>().text = firstQuestion.right;
        // GameObject.Find(buttons[3]).

    }
    // Update is called once per frame
    void Update () {
        // if(GameObject.Find(buttons[3]).OnClick())
        // {
        //     Start();
        // }
    }

    public void questionsReboot()
    {
        List <QuestionSet> questions = QuestionManager.levelOneQuestions;
        QuestionSet firstQuestion = questions[Random.Range(0, questions.Count)];
        QuestionForBattle.gameObject.SetActive(true);
        // GameObject.Find("Question1")
        QuestionForBattle.GetComponentInChildren<Text>().text = firstQuestion.question;
        Shuffle(buttons);
        GameObject.Find(buttons[0]).GetComponentInChildren<Text>().text = firstQuestion.wrong[0];
        GameObject.Find(buttons[1]).GetComponentInChildren<Text>().text = firstQuestion.wrong[1];
        GameObject.Find(buttons[2]).GetComponentInChildren<Text>().text = firstQuestion.wrong[2];
        GameObject.Find(buttons[3]).GetComponentInChildren<Text>().text = firstQuestion.right;
        // GameObject.Find(buttons[3]).
    }
}