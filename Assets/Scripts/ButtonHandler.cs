using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class ButtonHandler : MonoBehaviour
{
   
    //public void logUser () {
    //    Debug.Log("hello")
    //    Debug.Log("user id: " + FirebaseAuth.DefaultInstance.CurrentUser.UserId);
    //}

	public void SetText (string text)
    {
        ScoreScript.scoreValue += 10;
        Debug.Log(ScoreScript.scoreValue);
        //Debug.Log("answer 1: " + QuestionManager.levelOneQuestions[0].right);
        //Debug.Log(TestQuest.CurrentUserId);

        if (ScoreScript.scoreValue >= 40) {
            LevelScript.levelValue = 2;
        }
       if (ScoreScript.scoreValue >= 80) {
            LevelScript.levelValue = 3;
        }
        Text txt = transform.Find("Text").GetComponent<Text>();
        txt.text = text;
	}


    //private void WriteNewScore(string userId, int score)
    //{
    //    // Create new entry at /user-scores/$userid/$scoreid and at
    //    // /leaderboard/$scoreid simultaneously
    //    string key = mDatabase.Child("scores").Push().Key;
    //    Player entry = new Player(userId, score);
    //    Player player = new Player(newPlayer.Email, 1, 0, "null");
    //    Dictionary<string, Object> entryValues = entry.ToDictionary();

    //    Dictionary<string, Object> childUpdates = new Dictionary<string, Object>();
    //    childUpdates["/scores/" + key] = entryValues;
    //    childUpdates["/user-scores/" + userId + "/" + key] = entryValues;

    //    mDatabase.UpdateChildrenAsync(childUpdates);
    //}
}
