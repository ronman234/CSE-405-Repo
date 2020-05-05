using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnShoot : MonoBehaviour {

    public Transform powerUpPoint;
    public GameObject powerUp;        //Medkit prefab
    public Vector2 position;

    [SerializeField]
    private int num;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "bulletcollide")
        {
            EnemyAudioManager.instance.Play("Enemy", "ObstacleHit", gameObject);
            if (Random.Range(0,num) == 0)
            {
                Spawn();
                Debug.Log("Power Up Created!");
            }
            Destroy(gameObject);
        }
    }

    public void Spawn()
    {
        Instantiate(powerUp, powerUpPoint.position, powerUpPoint.rotation);
    }
}
