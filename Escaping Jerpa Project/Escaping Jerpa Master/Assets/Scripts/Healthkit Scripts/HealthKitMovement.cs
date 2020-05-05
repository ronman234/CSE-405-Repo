using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script to govern Health Kit movement

public class HealthKitMovement : MonoBehaviour {

    [SerializeField]
    private float movementSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += Vector3.left * movementSpeed * Time.deltaTime;   	
	}
}
