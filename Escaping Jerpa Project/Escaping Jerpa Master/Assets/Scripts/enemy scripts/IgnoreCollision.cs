using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour {

   
    public GameObject bullet;
 
    public GameObject enemyBullet;


    // Update is called once per frame
    void Update () {
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), enemyBullet.GetComponent<Collider2D>());
    }
}
