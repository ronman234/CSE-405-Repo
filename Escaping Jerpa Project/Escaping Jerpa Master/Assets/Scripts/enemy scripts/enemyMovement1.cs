using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {

    [SerializeField]
    private float movementSpeed;

    private float firstmovetime;
    private float awaymovetime;

	// Use this for initialization
	void Start () {
        firstmovetime = Random.Range(3f, 7f);
        awaymovetime = Random.Range(2f, 8f);
        Debug.Log("move");
	}
	
	// Update is called once per frame
	void Update () {
        firstmovetime -= Time.deltaTime;

        if (firstmovetime > 0)
        {
            moving();
        }
        else
        {
            awaymovetime -= Time.deltaTime;
            if (awaymovetime <= 0)
            {
                awaymoving();
            }
        }
		
	}

    void moving()
    {
        transform.position += Vector3.left * movementSpeed * Time.deltaTime;
    }

    void awaymoving()
    {
        transform.position += Vector3.up * movementSpeed * Time.deltaTime;
    }
}
