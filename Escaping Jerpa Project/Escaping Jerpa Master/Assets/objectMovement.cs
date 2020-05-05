using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectMovement : MonoBehaviour {

    [SerializeField]
    private float movementSpeed;    //speed of object
    [SerializeField]
    private float destroyTimer;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, destroyTimer);   //object destroys after 10 seconds
    }
	
	// Update is called once per frame
	void Update () {

        //object moves faster, slower, or at preset speed depending on if the player is moving forward, backward, or not moving
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * (movementSpeed * 0.9f) * Time.deltaTime);   
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.left * (movementSpeed * 1.2f) * Time.deltaTime);
        }
        else
            transform.position += Vector3.left * movementSpeed * Time.deltaTime;
    }
}
