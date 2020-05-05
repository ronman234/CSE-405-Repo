using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Spawn an enemy from Obstacle Point, random position and random time

public class enemySpawnUpdate : MonoBehaviour
{

    public Transform obstaclePoint;
    public GameObject enemyCopPrefab;   //enemy cop object
    public GameObject enemyMobPrefab;   //enemy mob object
    public GameObject sampWave;
    public GameObject sampWave2;

    public float spawning_timer;    //timer for when enemy spawns
    public Vector3 random_position;     // random position for where enemy spawns

    //spawn an obstacle continuously 
    void Update()
    {
        spawning_timer -= Time.deltaTime;   //decrease timer

        if (spawning_timer <= 0)
        {
            random_position = new Vector3(transform.position.x, (Random.Range(-7.0f, 5.0f)), 0);  //create vector at random x,y position
            Instantiate(enemyCopPrefab, random_position, obstaclePoint.rotation);   //create enemy at specified vector
            Instantiate(enemyMobPrefab, random_position, obstaclePoint.rotation);   //create enemy at specified vector
            Instantiate(sampWave, transform.position, obstaclePoint.rotation);
            Instantiate(sampWave2, (new Vector3(transform.position.x, transform.position.y + 3)), obstaclePoint.rotation);
            spawning_timer = Random.Range(.75f, 4.5f);  //wait a random amount of time for next obstacle creation
        }
    }


}
