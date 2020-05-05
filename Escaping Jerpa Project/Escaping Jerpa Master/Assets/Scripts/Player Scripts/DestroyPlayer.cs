using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//destroy player

public class DestroyPlayer : MonoBehaviour {

    public GameObject trail;

    void OnCollisionEnter2D(Collision2D coll)
    {      
        //destroy player if it collides with objects tagged as "death" or  "ostabletag"
        if (coll.gameObject.tag == "death" || coll.gameObject.tag == "obstacletag")
        {
            trail.transform.SetParent(null);
            
            Destroy(gameObject);
        }
    }

}
