using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWaveFire2 : MonoBehaviour {

    //enemy shooting 


    private float firingAnimTimer = .7f;

    [SerializeField]
    private Transform FirePoint;   //point where enemy bullets spawn

    [SerializeField]
    private GameObject BossWavePrefab, BossWavePrefab2;   //enemy bullet object

    //random range interval for firing rate
    [SerializeField]
    private float shootRate1;
    [SerializeField]
    private float shootRate2;

    private float firingrate = 3;

    public Transform target;
    private Vector3 v_diff;
    private float atan2;

    // Update is called once per frame
    void Update()
    {
        firingrate -= Time.deltaTime;

        if (firingrate <= 0)
        {
            firingAnimTimer -= Time.deltaTime;

            v_diff = (target.position - transform.position);
            atan2 = Mathf.Atan2(v_diff.x, v_diff.y);
            transform.rotation = Quaternion.Euler(0f, 0f, -atan2 * Mathf.Rad2Deg);

            if (firingAnimTimer <= 0)
            //StartCoroutine(time());
            {

                EnemyAudioManager.instance.Play("Enemy", "Wave", gameObject);
                Instantiate(BossWavePrefab, FirePoint.position, FirePoint.rotation);   //spawn enemy bullet
                Instantiate(BossWavePrefab2, new Vector2(FirePoint.position.x, FirePoint.position.y + 1), FirePoint.rotation);   //spawn enemy bullet
                firingrate = Random.Range(shootRate1, shootRate2);   //random time cooldown for when enemy can shoot again

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
