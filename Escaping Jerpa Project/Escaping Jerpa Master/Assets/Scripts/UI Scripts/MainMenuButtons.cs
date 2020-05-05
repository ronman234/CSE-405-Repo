using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;
    public GameObject controls;
    public GameObject scoreScreen;

	// Use this for initialization
	void Start ()
    {
        Button btn1 = startButton.gameObject.GetComponent<Button>();
        Button btn2 = quitButton.gameObject.GetComponent<Button>();

        btn1.onClick.AddListener(GameStart);
        btn2.onClick.AddListener(GameEnd);

        controls.SetActive(false);
        scoreScreen.SetActive(false);
	}

    void GameStart()
    {
        SceneManager.LoadScene("IntroText");
    }
	
    void GameEnd()
    {
        Application.Quit();
    }

    void Controls()
    {
        controls.SetActive(true);
        gameObject.SetActive(false);
    }

    void Scores()
    {
        scoreScreen.SetActive(true);
        gameObject.SetActive(false);
    }

	// Update is called once per frame
	void Update ()
    {
		if(Input.GetButtonDown("X"))
        {
            GameStart();
        }
        if (Input.GetButtonDown("Circle"))
        {
            GameEnd();
        }
        if (Input.GetButtonDown("Square"))
        {
            Controls();
        }
    }
}
