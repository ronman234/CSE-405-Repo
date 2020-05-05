using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sampleNegSine : MonoBehaviour
{
    private Rigidbody2D rb;

    private float translateX = 0.0f;

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
        translateX = sine2 * -Mathf.Sin(counter/2);
        rb.transform.Translate(0, translateX, 0);
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
