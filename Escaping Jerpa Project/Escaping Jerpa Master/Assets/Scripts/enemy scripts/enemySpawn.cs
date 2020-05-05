using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Spawn an enemy from Obstacle Point, random position and random time

public class enemySpawn : MonoBehaviour
{

    public Transform obstaclePoint; //point where object spawns
    public GameObject enemyprefab;   //enemy cop object

    [SerializeField]
    private float spawning_timer = 2;    //timer for when enemy first spawns
    private Vector3 random_position;     // random position for where enemy spawns

    [SerializeField]
    private float randomSpawntimer1, randomSpawntimer2; //used as an interval for spawn time (randomSpawntimer1 is the lower value)

    [SerializeField]
    private float randomSpawnPos1, randomSpawnPos2; //used as an interval for y axis random spawn (randomSpawnPos1 is the lower value)



    //spawn an obstacle continuously 
    void Update()
    {
        spawning_timer -= Time.deltaTime;   //decrease timer

        if (spawning_timer <= 0)
        {
            random_position = new Vector3(transform.position.x, (Random.Range(randomSpawnPos1, randomSpawnPos2)), 0);  //create vector at random x,y position
            Instantiate(enemyprefab, random_position, obstaclePoint.rotation);   //create enemy at specified vector
            spawning_timer = Random.Range(randomSpawntimer1, randomSpawntimer2);  //wait a random amount of time for next obstacle creation
        }
    }


}
