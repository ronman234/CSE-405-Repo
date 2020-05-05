using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpreadShoot : MonoBehaviour
{
    [SerializeField]
    private Transform enemyFirepoint;   //point where enemy bullets spawn
    [SerializeField]
    private GameObject enemyBulletPrefab;   //enemy bullet object
    [SerializeField]
    private float enemyShootingRate;    //rate at which enemy fires bullets

    // Update is called once per frame
    void Update()
    {
        
        enemyShootingRate -= Time.deltaTime;

        if (enemyShootingRate <= 0)
        {
            EnemyAudioManager.instance.Play("Enemy", "Spread", gameObject);
            Instantiate(enemyBulletPrefab, enemyFirepoint.position, Quaternion.Euler(0, 0, -10));   //spawn enemy bullet
            Instantiate(enemyBulletPrefab, enemyFirepoint.position, Quaternion.Euler(0, 0, -5));
            Instantiate(enemyBulletPrefab, enemyFirepoint.position, Quaternion.Euler(0, 0, 0));
            Instantiate(enemyBulletPrefab, enemyFirepoint.position, Quaternion.Euler(0, 0, 5));
            Instantiate(enemyBulletPrefab, enemyFirepoint.position, Quaternion.Euler(0, 0, 10));
            enemyShootingRate = Random.Range(2f, 4f);   //random time cooldown for when enemy can shoot again
        }

    }
}
