using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStunned : MonoBehaviour {

    [SerializeField]
    private Animator stunned;

	// Update is called once per frame
	void Start () {
        stunned.SetBool("isStun", false);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "stun")
        {
            stunned.SetBool("isStun", true);
            StartCoroutine(stunTime());
        }
    }

    IEnumerator stunTime()
    {
        yield return new WaitForSeconds(3);
        stunned.SetBool("isStun", false);
    }
}
