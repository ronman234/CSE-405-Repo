using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour {

    [SerializeField]
    private Animator destroyanim;

    [SerializeField]
    private int health = 10;

    private int currentHealth;
    private ScoreScript scoreController;
    private GameObject scoreControllerObject;

    public bool spawn = false;

    [SerializeField]
    private int score;

    void Start()
    {      
        destroyanim.SetBool("isdestroy", false);
        currentHealth = health;

        scoreControllerObject = GameObject.FindGameObjectWithTag("ScoreController");
        if (scoreControllerObject)
        {
            scoreController = scoreControllerObject.GetComponent<ScoreScript>();
        }
        if (!scoreControllerObject)
        {
            Debug.Log("No score script found");
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        //destroy enemy if it collides with objects tagged "bulletcollide"
        if (coll.gameObject.tag == "bulletcollide")
        {
            currentHealth -= 5;
            if (currentHealth <= 0)
            {
                EnemyScore();
            }
        }
    }

    IEnumerator time()
    {
        yield return new WaitForSeconds(.50f);
        Destroy(gameObject);

    }

    public void EnemyScore()
    {
        EnemyAudioManager.instance.Play("Enemy", "Death", gameObject);
        GetComponent<Collider2D>().enabled = false;
        destroyanim.SetBool("isdestroy", true);
        StartCoroutine(time());
        if (spawn)
        {
            GetComponent<SpawnOnShoot>().Spawn();
        }
        scoreController.AddScore(score);
    }
    
}
