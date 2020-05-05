using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parabolaPath : MonoBehaviour {

    [SerializeField]
    private float speedx = 5;
    [SerializeField]
    private float speedy= 5f;
	
	// Update is called once per frame
	void Update () {
        speedy -= 10 * Time.deltaTime;

        transform.Translate(Vector2.left * speedx * Time.deltaTime);
        transform.Translate(Vector2.up * speedy * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
