using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour {

    public Transform objectPoint;

    [SerializeField]
    private GameObject civ_car;

    private float startTimer = .5f;

    [SerializeField]
    private float newTimer;
	
	// Update is called once per frame
	void Update () {
        startTimer -= Time.deltaTime;
        if (startTimer <= 0)
        {
            Instantiate(civ_car, new Vector3(objectPoint.position.x, objectPoint.position.y + (Random.Range(-1f, -1.35f))), objectPoint.rotation);
            Instantiate(civ_car, new Vector3(objectPoint.position.x + 2, objectPoint.position.y + (Random.Range(3f,3.35f))), objectPoint.rotation);
            startTimer = newTimer;

        }
    }
}
