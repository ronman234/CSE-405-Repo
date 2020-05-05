using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailEcho : MonoBehaviour {

    private float spawnTime;
    [SerializeField]
    private float startSpawn;

    [SerializeField]
    private GameObject echo;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (spawnTime <= 0)
        {
            GameObject instance = (GameObject)Instantiate(echo, transform.position, Quaternion.identity);
            Destroy(instance, .75f);
            spawnTime = startSpawn;
        }
        else spawnTime -= Time.deltaTime;
	}
}
