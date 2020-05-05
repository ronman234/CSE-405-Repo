using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDeflectShield : MonoBehaviour
{
    [SerializeField]
    private Transform enemyFirepoint;   //point where enemy bullets spawn
    [SerializeField]
    private GameObject enemyBulletPrefab;   //enemy bullet object
    [SerializeField]
    private float enemyShootingRate;    //rate at which enemy fires bullets

    void OnCollisionEnter2D(Collision2D coll)
    {
        //check collision for objects that collide with player
        if (coll.gameObject.tag == "bulletcollide")
        {
            Destroy(gameObject);
            Instantiate(enemyBulletPrefab, enemyFirepoint.position, Quaternion.Euler(0, 0, -150));
            Instantiate(enemyBulletPrefab, enemyFirepoint.position, Quaternion.Euler(0, 0, -120));
            Instantiate(enemyBulletPrefab, enemyFirepoint.position, Quaternion.Euler(0, 0, -90));
            Instantiate(enemyBulletPrefab, enemyFirepoint.position, Quaternion.Euler(0, 0, -60));   //spawn enemy bullet
            Instantiate(enemyBulletPrefab, enemyFirepoint.position, Quaternion.Euler(0, 0, -30));
            Instantiate(enemyBulletPrefab, enemyFirepoint.position, Quaternion.Euler(0, 0, 0));
            Instantiate(enemyBulletPrefab, enemyFirepoint.position, Quaternion.Euler(0, 0, 30));
            Instantiate(enemyBulletPrefab, enemyFirepoint.position, Quaternion.Euler(0, 0, 60));
            Instantiate(enemyBulletPrefab, enemyFirepoint.position, Quaternion.Euler(0, 0, 90));
            Instantiate(enemyBulletPrefab, enemyFirepoint.position, Quaternion.Euler(0, 0, 120));
            Instantiate(enemyBulletPrefab, enemyFirepoint.position, Quaternion.Euler(0, 0, 150));
            Instantiate(enemyBulletPrefab, enemyFirepoint.position, Quaternion.Euler(0, 0, 180));
            enemyShootingRate = Random.Range(2f, 4f);   //random time cooldown for when enemy can shoot again
        }
    }
}
