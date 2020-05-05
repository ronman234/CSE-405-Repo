using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossNegSinWave : MonoBehaviour {

    private Rigidbody2D rb;

    private float translateY = 0.0f;

    [SerializeField]
    private float sine1;
    [SerializeField]
    private float sine2;

    private float counter;


    [SerializeField]
    private GameObject wTrail;

    void Start()
    {

        rb = gameObject.GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5f);

    }    // Update is called once per frame

    void Update()
    {
        transform.position += Vector3.left * 6f * Time.deltaTime;
        counter += sine1;

        Strafing();

    }
    void Strafing()
    {
        translateY = sine2 * -Mathf.Sin(counter/2);

        rb.transform.Translate(0, translateY, 0);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "playershipdef")
        {
            wTrail.transform.SetParent(null);
            Destroy(gameObject);
        }
    }
}