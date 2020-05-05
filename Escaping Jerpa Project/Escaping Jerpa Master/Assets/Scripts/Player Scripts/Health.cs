using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public Slider healthSlider;

    [SerializeField]
    private int maxHealth = 100;

    private int currentHealth;
    public GameObject trail;

    private bool isStunned = false;
    private float timer = 3;
    private GameOverScript gameOverScript;

    private Color MaxHealth = Color.green;
    private Color MidHealh = Color.yellow;
    private Color MinHealth = Color.red;

    public Image fill;

	// Use this for initialization
	void Start ()
    {
        healthSlider.value = maxHealth;
        currentHealth = maxHealth;
        fill.color = MaxHealth;

        GameObject gameOverObject = GameObject.FindGameObjectWithTag("GameOverMenu");
        if(gameOverObject)
        {
            gameOverScript = gameOverObject.GetComponent<GameOverScript>();
        }
        if(!gameOverObject)
        {
            Debug.Log("No Game Over Menu Found");
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(currentHealth >= 76)
        {
            fill.color = MaxHealth;
        }
        else if(currentHealth <= 75 && currentHealth >= 26)
        {
            fill.color = MidHealh;
        }
        else if(currentHealth <= 25)
        {
            fill.color = MinHealth;
        }
		if(currentHealth <= 0)
        {
            OnDeath();
        }

        if(isStunned)
        {
            gameObject.GetComponent<PCmovement>().enabled = false;
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                isStunned = false;
                gameObject.GetComponent<PCmovement>().enabled = true;
                timer = 3;
            }
        }
	}

    void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        healthSlider.value = currentHealth;
    }

    void GiveHealth(int health)
    {
        currentHealth += health;
        healthSlider.value = currentHealth;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //check collision for objects that collide with player
        if (coll.gameObject.tag == "death" || coll.gameObject.tag == "obstacletag" || coll.gameObject.tag == "stun")
        {
            if (coll.gameObject.tag == "obstacletag")   //destroy player regardless of health if collision with obstacle
            {
                //Destroy(gameObject);
                TakeDamage(currentHealth);
            }
            else if(coll.gameObject.tag == "stun")
            {
                isStunned = true;
            }
            else
                TakeDamage(5);
        }

        //collision check for medkits
        if (coll.gameObject.tag == "medkit")
        {
            Destroy(coll.gameObject);
            GiveHealth(5);
        }
    }

    void OnDeath()
    {
        trail.transform.SetParent(null); //seperate trail from parent player object
        Destroy(gameObject); // destroy player
        AudioManager.instance.StopBack();
        gameOverScript.b_isDead();

        //SceneManager.LoadScene("MainMenu");
    }
}
