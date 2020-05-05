using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// Creates a Game Over screen that freezes the game and shows the buttons
/// </summary>
public class GameOverScript : MonoBehaviour
{
    private GameObject[] gameOverObjects;
    public Button Quit, Restart, MainMenu;
    private bool isDead;
    // Use this for initialization
    void Start ()
    {
        isDead = false;
        Time.timeScale = 1;
        gameOverObjects = GameObject.FindGameObjectsWithTag("GameOver");
        hideMenu();

        Button qButton, rButton, mButton;
        qButton = Quit.GetComponent<Button>();
        rButton = Restart.GetComponent<Button>();
        mButton = MainMenu.GetComponent<Button>();

        qButton.onClick.AddListener(End);
        rButton.onClick.AddListener(RestartGame);
        mButton.onClick.AddListener(MainScreen);
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(isDead)
        {
            Time.timeScale = 0;
            showMenu();
        }
	}

    public void b_isDead()
    {
        isDead = true;
    }

    public void hideMenu()
    {
        foreach(GameObject g in gameOverObjects)
        {
            g.SetActive(false);
        }
    }

    public void showMenu()
    {
        foreach (GameObject g in gameOverObjects)
        {
            g.SetActive(true);
        }
    }

    void End()
    {
        Application.Quit();
    }

    void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    void MainScreen()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
