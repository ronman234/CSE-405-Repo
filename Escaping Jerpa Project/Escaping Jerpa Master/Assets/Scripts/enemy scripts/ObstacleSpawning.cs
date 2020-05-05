using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Spawn an obstacle from Obstacle Point, random position and random time

public class ObstacleSpawning : MonoBehaviour {

    public Transform obstaclePoint; 
    public GameObject obstaclePrefab;   //ostable object

    public float spawning_timer;    //timer for when obstacle spawns
    public Vector3 random_position;     // random position for where object spawns

    //spawn an obstacle continuously 
    void Update()
    {
        spawning_timer -= Time.deltaTime;   //decrease timer

        if(spawning_timer <= 0)
        {
            random_position = new Vector3(transform.position.x, (Random.Range(-5.0f, 5.0f)), 0);  //create vector at random x,y position
            Instantiate(obstaclePrefab, random_position, obstaclePoint.rotation);   //create object at specified vector
            spawning_timer = Random.Range(5f,20f);  //wait a random amount of time for next obstacle creation
        }
    }


}
