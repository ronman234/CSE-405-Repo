using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defMobEnemyMove : MonoBehaviour
{

    [SerializeField]
    private float movementSpeed;    //enemy movement speed when spawned
    
    private Transform targetPlayer;

    private float firstmovetime;    //amount of time enemy moves when first spawned
    private float stationaryTime;   //amount of time enemy is stationary after firstmovetime reaches 0
    private int upordown;         //whether enemy moves up or down offscreen 

    //[SerializeField]
    //private Animator defcopanim;


    // Use this for initialization
    void Start()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        //set timers
        firstmovetime = Random.Range(1f, 1.5f);
        stationaryTime = Random.Range(4f, 10f);
        //set number to see whether enemy moves up or down
        upordown = Random.Range(0, 3);

    }

    // Update is called once per frame
    void Update()
    {
        firstmovetime -= Time.deltaTime;

        //enemy moves while firstmovetime is greater than 0
        if (firstmovetime > 0)
        {
            moving();
        }
        else
        {
            stationaryTime -= Time.deltaTime;
            if (stationaryTime > 0)
            {
                //enemy follows player's y axis only
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, targetPlayer.position.y), 4f * Time.deltaTime);
            }
            //enemy stays stationary until stationaryTime is 0 or less than 0
            if (stationaryTime <= 0)
            {
                movementSpeed = 5.5f;   //set new movement speed for when enemy moves off screen

                //if upordown is greater than 0, enemy moves down offscreen, else enemy moves up offscreen
                if (upordown > 1)
                {
                    awaymovingdown(); 
                }
                else
                {                   
                    awaymovingup();
                }
            }
        }

    }

    //enemy moving while firstmovetime is not 0
    void moving()
    {
        transform.position += Vector3.left * movementSpeed * Time.deltaTime;
    }

    //enemy moves down offscreen
    void awaymovingdown()
    {
        transform.position += Vector3.up * movementSpeed * Time.deltaTime;
        transform.position += Vector3.left * movementSpeed * Time.deltaTime;
        Destroy(gameObject, 4f);
    }

    //enemy moves up offscreen
    void awaymovingup()
    {
        transform.position += Vector3.down * movementSpeed * Time.deltaTime;
        transform.position += Vector3.left * movementSpeed * Time.deltaTime;
        Destroy(gameObject, 3f);
    }
}

