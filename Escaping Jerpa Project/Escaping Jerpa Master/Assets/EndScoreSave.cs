using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.UI;

public class EndScoreSave : MonoBehaviour
{
    DatabaseReference reference;

    ScoreScript scoreScript;

    Text finalScore;

    InputField playerName;

    int numberOfPlyrs;

    long childrenAmnt;

    string json;

    bool isPlayer = false;

    int scoreNumber;

    // Start is called before the first frame update
    void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://cse-405-project.firebaseio.com/");

        reference = FirebaseDatabase.DefaultInstance.GetReference("LeaderBoard");

        scoreScript = GameObject.FindGameObjectWithTag("ScoreController").GetComponent<ScoreScript>();

        finalScore.text = scoreScript.scoreKeeper.ToString();

        reference.ValueChanged += HandleValueChanged;

        numberOfPlyrs = GameObject.FindGameObjectWithTag("database").GetComponent<DatabseScoreList>().playerAmnt;
    }

    public void updateScore()
    {
        for (int i = 1; i <= numberOfPlyrs; i++)
        {
            FirebaseDatabase.DefaultInstance.GetReference("LeaderBoard").Child("Score " + i).Child("Player Name").GetValueAsync().ContinueWith(task =>
            {
                if(task.IsFaulted)
                {
                    return;
                }
                else if(task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                    if((string)snapshot.Value == playerName.text)
                    {
                        reference.Child("Score " + (i)).Child("Player Score").SetValueAsync(finalScore.text);
                        return;
                    }
                }
            });
        }

        //for(int j = 1; j <= numberOfPlyrs; j++)
        //{

        //}
    }

    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }

    }
}
