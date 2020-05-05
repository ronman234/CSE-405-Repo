using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour {

    [SerializeField]
    private float movementSpeed;

    GameObject[] enemies;

	// Use this for initialization
	void Awake ()
    {
        Physics2D.IgnoreLayerCollision(10, 10);	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Physics2D.IgnoreLayerCollision(10, 10);
        transform.position += Vector3.right * movementSpeed * Time.deltaTime;
        StartCoroutine(time());
	}

    IEnumerator time()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D (Collision2D coll)
    {
        if (coll.gameObject.tag == "death")
        {
            enemies = GameObject.FindGameObjectsWithTag("death");
        }
        foreach (GameObject enemy in enemies)
        {
            ScorePoints(enemy);
            //Destroy(enemy);
        }
        Destroy(gameObject);
    }

    //Adds score value of each enemy destroyed in A-bomb explosion to player's score.
    void ScorePoints(GameObject e)
    {
        e.GetComponent<DestroyEnemy>().EnemyScore();
    }
}
