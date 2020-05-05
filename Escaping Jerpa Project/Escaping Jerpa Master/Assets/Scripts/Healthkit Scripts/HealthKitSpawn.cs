using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Spawns a HealtKit from HealthKit spawn point

public class HealthKitSpawn : MonoBehaviour {

    public Transform healthkitPoint;
    public GameObject healthKit;        //Healthkit prefab
    public Vector3 position;
    public float spawnTimer;
    //private bool hit = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            position = new Vector3(11, (Random.Range(-5.0f, 5.0f)), 0);
            Instantiate(healthKit, position, healthkitPoint.rotation);
            spawnTimer = Random.Range(5f, 7.5f);
        }
	}

    /*void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "bulletcollide")
        {
            position = new Vector3(11, (Random.Range(-5.0f, 5.0f)), 0);
            Instantiate(healthKit, position, healthkitPoint.rotation);
            hit = true;
        }
    }*/
}
