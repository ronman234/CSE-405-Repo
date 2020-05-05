using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombThrowSpawn : MonoBehaviour
{

    //spawn bombs for enemy bomb thrower

    [SerializeField]
    private Animator throwing;

    [SerializeField]
    private Transform enemyFirepoint1, enemyFirepoint2, enemyFirepoint3;   //point where enemy bullets spawn

    [SerializeField]
    private GameObject enemyBulletPrefab;   //enemy bullet object

    [SerializeField]
    private float enemyShootingRate;    //rate at which enemy fires bullets
    private float shootrate2, shootrate3;

    void Start()
    {
        shootrate2 = enemyShootingRate + .05f;
        shootrate3 = enemyShootingRate + .1f;
    }

    // Update is called once per frame
    void Update()
    {

        enemyShootingRate -= Time.deltaTime;
        shootrate2 -= Time.deltaTime;
        shootrate3 -= Time.deltaTime;

        if (enemyShootingRate < .12f)
        {
            throwing.SetBool("isShooting", true);
        }

        if (enemyShootingRate <= 0)
        {
            throwbomb1();
        }
        if (shootrate2 <= 0)
        {
            throwbomb2();
        }
        if (shootrate3 <= 0)
        {
            throwbomb3();
        }

    }

    void throwbomb1()
    {
        EnemyAudioManager.instance.Play("Enemy", "Bomb", gameObject);
        Instantiate(enemyBulletPrefab, enemyFirepoint1.position, enemyFirepoint1.rotation);   //spawn enemy bullet
        enemyShootingRate = 3f;
    }
    void throwbomb2()
    {
        EnemyAudioManager.instance.Play("Enemy", "Bomb", gameObject);
        Instantiate(enemyBulletPrefab, enemyFirepoint2.position, enemyFirepoint2.rotation);   //spawn enemy bullet
        shootrate2 = 3.05f;
    }
    void throwbomb3()
    {
        EnemyAudioManager.instance.Play("Enemy", "Bomb", gameObject);
        Instantiate(enemyBulletPrefab, enemyFirepoint3.position, enemyFirepoint3.rotation);   //spawn enemy bullet
        shootrate3 = 3.07f;

        throwing.SetBool("isShooting", false);
    }

}
