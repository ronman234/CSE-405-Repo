using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMovement : MonoBehaviour {

    [SerializeField]
    private float speed;

    [SerializeField]
    private float destroyBulletTime;
   
	// Use this for initialization
	void Start () {     
        Destroy(gameObject, destroyBulletTime);
    }

    void Update()
    {        
        Physics2D.IgnoreLayerCollision(10, 10);
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //destroy bullet if it hits anything that isn't the player
        if (coll.gameObject.tag != "player" & coll.gameObject.tag != "bound")
        {            
            Destroy(gameObject);
        }
    }



}
