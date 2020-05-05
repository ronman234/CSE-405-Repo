using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobThrowMovement : MonoBehaviour {

    [SerializeField]
    private float movementSpeed;

    private float firstmovetime;    //amount of time object moves into screen
    private float awaymovetime; //amount of time objects stays stationary until moves out of screen

    // Use this for initialization
    void Start () {
        //set random time for timers
        firstmovetime = Random.Range(2f, 3f);   
        awaymovetime = Random.Range(4f, 8f);
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
        transform.position += Vector3.right * movementSpeed * Time.deltaTime;
        Destroy(gameObject, 10f);
    }
}
