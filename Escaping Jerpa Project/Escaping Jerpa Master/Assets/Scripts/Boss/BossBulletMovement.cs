using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletMovement : MonoBehaviour {

    [SerializeField]
    private float speed;
    [SerializeField]
    private float destroyBulletTime;

    // Use this for initialization
    void Start()
    {

        // transform.Rotate(new Vector3(0, 0, 180));


        Destroy(gameObject, destroyBulletTime);
    }

    void Update()
    {

        Physics2D.IgnoreLayerCollision(10, 10); //ignore any collisions with objects in layer 10 to other objects in layer 10 (bullet layer)
        transform.Translate(Vector2.up * speed * Time.deltaTime);

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "playershipdef")
        {
            Destroy(gameObject);
        }
    }
}
