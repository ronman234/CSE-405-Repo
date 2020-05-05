using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Database;

public class EndGameScore : MonoBehaviour
{
    private FirebaseDatabase _database;

    private ScoreScript score;

    public Text finalScore;
    public InputField playerInput;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("ScoreController").GetComponent<ScoreScript>();
        if (score)
            Debug.Log("Found the score");

        _database = FirebaseDatabase.DefaultInstance;
    }

    // Update is called once per frame
    void Update()
    {
        finalScore.text = "Final Score: " + score.scoreKeeper;
    }

    public void SaveScore()
    {
        PlayerPrefs.SetString("Player Name", playerInput.text);
        PlayerPrefs.SetInt("Player Score", score.scoreKeeper);

        //_database.GetReference(playerInput.text).SetRawJsonValueAsync(JsonUtility.ToJson())
    }
}
