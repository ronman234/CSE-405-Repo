using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpreadShooting : MonoBehaviour
{   
    [SerializeField]
    private Transform FirePoint;   //point where enemy bullets spawn
    [SerializeField]
    private GameObject BossBulletPreFab;   //enemy bullet object
    [SerializeField]
    private float enemyShootingRate;    //rate at which enemy fires bullets

    public Transform target;
    private Vector3 v_diff;
    private float atan2;

    // Update is called once per frame
    void Update()
    {

        enemyShootingRate -= Time.deltaTime;

        if (enemyShootingRate <= 0)
        {
            v_diff = (target.position - transform.position);
            atan2 = Mathf.Atan2(v_diff.x, v_diff.y);
            transform.rotation = Quaternion.Euler(0f, 0f, -atan2 * Mathf.Rad2Deg);
            //Quaternion bulletAngle1 = transform.rotation;
            //bulletAngle1.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 15.0f);
            EnemyAudioManager.instance.Play("Enemy", "SpreadShoot", gameObject);
            Instantiate(BossBulletPreFab, FirePoint.position, AngleConverter(15.0f));   //spawn enemy bullet
            Instantiate(BossBulletPreFab, FirePoint.position, AngleConverter(30.0f));
            Instantiate(BossBulletPreFab, FirePoint.position, transform.rotation);
            Instantiate(BossBulletPreFab, FirePoint.position, AngleConverter(-15.0f));
            Instantiate(BossBulletPreFab, FirePoint.position, AngleConverter(-30.0f));
            enemyShootingRate = Random.Range(2f, 4f);   //random time cooldown for when enemy can shoot again
        }

    }

    private Quaternion AngleConverter(float angle)
    {
        Quaternion bulletAngle = transform.rotation;
        bulletAngle.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + angle);
        return bulletAngle;
    }
}
