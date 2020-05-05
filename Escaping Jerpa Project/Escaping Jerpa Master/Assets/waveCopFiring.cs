using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveCopFiring : MonoBehaviour
{

    //enemy shooting 


    private float firingAnimTimer = .7f;

    [SerializeField]
    private Animator shooting;

    [SerializeField]
    private Transform enemyFirepoint;   //point where enemy bullets spawn
    [SerializeField]
    private GameObject enemyBulletPrefab;   //enemy bullet object

    //random range interval for firing rate
    [SerializeField]
    private float shootRate1;    
    [SerializeField]
    private float shootRate2;

    private float firingrate = 3;

    void Start()
    {
        shooting.SetBool("ifShooting", false);
    }

    // Update is called once per frame
    void Update()
    {
        firingrate -= Time.deltaTime;

        if (firingrate <= 0)
        {
            shooting.SetBool("ifShooting", true);
            firingAnimTimer -= Time.deltaTime;
            if (firingAnimTimer <= 0)
            //StartCoroutine(time());
            {
                EnemyAudioManager.instance.Play("Enemy", "BasicWave", gameObject);
                Instantiate(enemyBulletPrefab, enemyFirepoint.position, enemyFirepoint.rotation);   //spawn enemy bullet
                firingrate = Random.Range(shootRate1, shootRate2);   //random time cooldown for when enemy can shoot again
                shooting.SetBool("ifShooting", false);
                firingAnimTimer = .7f;
            }
            /*Instantiate(enemyBulletPrefab, enemyFirepoint.position, enemyFirepoint.rotation);   //spawn enemy bullet
            firingrate = Random.Range(enemyShootingRate1, enemyShootingRate2);   //random time cooldown for when enemy can shoot again
            shooting.SetBool("ifShooting", false);*/
        }

    }
    /*
    IEnumerator time()
    {
        shooting.SetBool("ifShooting", true);
        yield return new WaitForSeconds(3);
    }
    */
}
