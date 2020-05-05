using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{
    private Button start;

	// Use this for initialization
	void Start ()
    {
        start = gameObject.GetComponent<Button>();
        start.onClick.AddListener(BeginGame);
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetButtonDown("X"))
        {
            BeginGame();
        }
	}

    public void BeginGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
