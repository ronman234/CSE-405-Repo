using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikerMovement : MonoBehaviour {

    [SerializeField]
    private float firstMoveTimer = 1;
    [SerializeField]
    private float speed = 1;
    [SerializeField]
    private float stationaryTime = 1;
	
	// Update is called once per frame
	void Update () {

        firstMoveTimer -= Time.deltaTime;
        if (firstMoveTimer >= 0)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else StartCoroutine(time());
        
    }

    IEnumerator time()
    {
        yield return new WaitForSeconds(stationaryTime);
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        Destroy(gameObject, 3);
    }
}
