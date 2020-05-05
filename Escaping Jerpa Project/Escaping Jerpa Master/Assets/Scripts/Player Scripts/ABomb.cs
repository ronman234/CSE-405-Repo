using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABomb : MonoBehaviour {

    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private float secondsToDestroy;

    GameObject[] enemies;

	// Use this for initialization
	void Awake ()
    {
        Physics2D.IgnoreLayerCollision(10, 10);	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Physics2D.IgnoreLayerCollision(10, 10);
        transform.position += Vector3.left * movementSpeed * Time.deltaTime;
        StartCoroutine(time());
    }

    IEnumerator time()
    {
        yield return new WaitForSeconds(secondsToDestroy);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D (Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            coll.gameObject.GetComponent<weaponController>().aBombBool = true;
            Destroy(gameObject);
        }
    }
}
