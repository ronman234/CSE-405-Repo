using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

    DatabaseReference reference;

    private string[] highScores;

    public Text[] scoreList;

    string json = "";

    long childrenAmnt;

    // Use this for initialization
    void Start ()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://cse-405-project.firebaseio.com/");

        reference = FirebaseDatabase.DefaultInstance.RootReference;

        //reference.ValueChanged += HandleValueChanged;
        //reference.ChildChanged += HandleChildChanged;
        FirebaseDatabase.DefaultInstance.GetReference("LeaderBoard").OrderByKey().ValueChanged += HandleValueChanged;

        highScores = new string[10];
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}


    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        if(args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }

        childrenAmnt = args.Snapshot.ChildrenCount;
        for (int i = 1; i <= childrenAmnt ; i++)
        {
            json = (string)args.Snapshot.Child("Score " + i).Child("Player Name").Value + " : " + args.Snapshot.Child("Score " + i).Child("Player Score").Value;

            highScores[i - 1] = json;
            Debug.Log(highScores[i - 1]);
            //json = (string)args.Snapshot.Child("Score " + i).Child("Player Name").Value;
            //Debug.Log(json);
        }

        for(int j = 0; j < childrenAmnt; j++)
        {
            scoreList[j].text = highScores[j]; 
        }

        GameObject.FindGameObjectWithTag("database").GetComponent<DatabseScoreList>().playerAmnt = (int)childrenAmnt;
    }

    void HandleChildChanged(object sender, ChildChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        // Do something with the data in args.Snapshot
        json = JsonUtility.ToJson(args.Snapshot);
        if (json != "")
        {
            Debug.Log("database found fool");
            Debug.Log(json);
        }
    }

    public void getScores(out string[] scoreList)
    {
        scoreList = highScores;
    }
}
