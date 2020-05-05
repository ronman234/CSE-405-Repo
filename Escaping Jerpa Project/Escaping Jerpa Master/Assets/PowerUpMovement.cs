using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMovement : MonoBehaviour {

    [SerializeField]
    private float timer;

    [SerializeField]
    private float secondsToDestroy;

    void Awake()
    {
        Physics2D.IgnoreLayerCollision(10, 10);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(time());
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            coll.gameObject.GetComponent<weaponController>().powerBool = true;
            coll.gameObject.GetComponent<weaponController>().timer = 5.0f;
            Destroy(gameObject);
        }
    }

    IEnumerator time()
    {
        yield return new WaitForSeconds(secondsToDestroy);
        Destroy(gameObject);
    }
}
