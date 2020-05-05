using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour 
{

    [SerializeField]
    private float speed = 1;

    [SerializeField]
    private float timer = 1;

    [SerializeField]
    private float spawntimer = 1;

    [SerializeField]
    private float stoptimer = 1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        spawntimer -= Time.deltaTime;

        if(spawntimer <= 0)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            stoptimer -= Time.deltaTime;
            spawntimer = 0;

            if(stoptimer <= 0)
            {
                speed = 0;
                GetComponent<Collider2D>().enabled = true;
                stoptimer = 0;
                GetComponent<BossRotation>().enabled = true;
            }

        }
    }
}
