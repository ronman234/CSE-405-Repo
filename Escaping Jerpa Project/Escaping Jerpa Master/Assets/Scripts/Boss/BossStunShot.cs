using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStunShot : MonoBehaviour 
{

    [SerializeField]
    private Transform FirePoint;   //point where enemy bullets spawn
    [SerializeField]
    private GameObject BossStunPreFab;   //enemy bullet object
    [SerializeField]
    private float enemyShootingRate;    //rate at which enemy fires bullets

    //public Transform target;
    private Vector3 v_diff;
    private float atan2;

    // Update is called once per frame
    void Update()
    {

        enemyShootingRate -= Time.deltaTime;

        if (enemyShootingRate <= 0)
        {
            //v_diff = (target.position - transform.position);
            //atan2 = Mathf.Atan2(v_diff.x, v_diff.y);
            //transform.rotation = Quaternion.Euler(0f, 0f, -atan2 * Mathf.Rad2Deg);
            //Quaternion bulletAngle1 = transform.rotation;
            //bulletAngle1.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 15.0f);

            Instantiate(BossStunPreFab, FirePoint.position, FirePoint.rotation);
            enemyShootingRate = Random.Range(2f, 4f);   //random time cooldown for when enemy can shoot again
        }

    }
}
