using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLegsDeath : MonoBehaviour {

    [SerializeField]
    private GameObject HoverBoss;

    [SerializeField]
    private Animator BossLegs;

    [SerializeField]
    private float speed = 1f;

    // Use this for initialization
    void Start () {
        BossLegs.SetBool("isDeath", true);
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 9);

        HoverBoss.GetComponent<BossSpawn>().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

    }
}
