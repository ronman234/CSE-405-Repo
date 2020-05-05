using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour {

    [SerializeField]
    private float speed;
    [SerializeField]
    private float destroyObstacleTime;

    public Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        //Vector3 position = new Vector3(0, (Random.Range(-1.0f, 0.0f)), 0);

        transform.Rotate(new Vector3(180, 0, 180));
        rb.velocity = transform.right * speed;

        Destroy(gameObject, destroyObstacleTime);
    }
}
