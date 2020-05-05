using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerShoot : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    void OnCollision2DEnter(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
          coll.gameObject.GetComponent<PlayerSpreadShoot>().enabled = true;
    }
}
