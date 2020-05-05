using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sampdestroy : MonoBehaviour {

    [SerializeField]
    private Transform x;

    public GameObject y;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "bulletcollide")
        {
            Instantiate(y, x.position, x.rotation);   //spawn enemy bullet
            Destroy(gameObject);
        }
    }
}
