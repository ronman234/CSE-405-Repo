using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLegsHealth : MonoBehaviour
{
    [SerializeField]
    private GameObject Turret;

    [SerializeField]
    private int health = 100;

    private int currentHealth;

    //public Slider  BossHealthSlider;

    void Start()
    {
        //destroyanim.SetBool("isdestroy", false);
        currentHealth = health;

        //BossHealthSlider = GetComponent < Slider> ();
        //BossHealthSlider.value = health;
    }

    /*public int Health
    {
        get { return health; }
        set
        {
            health -= value;
            if (currentHealth >= 75)
            {
                GetComponent<BossBulletSingle>().enabled = true;

                if (currentHealth <= 75 && currentHealth >= 50)
                {
                    GetComponent<BossBulletSingle>().enabled = false;

                    GetComponent<BossMovement>().enabled = true;
                    GetComponent<BossSpreadShooting>().enabled = true;

                    if (currentHealth <= 50 && currentHealth >= 25)
                    {

                        if (currentHealth <= 25 && currentHealth >= 0)
                        {


                        }
                    }
                }

            }
        }
    }*/

    void OnCollisionEnter2D(Collision2D coll)
    {
        //destroy enemy if it collides with objects tagged "bulletcollide"
        if (coll.gameObject.tag == "bulletcollide")
        {
            currentHealth -= 5;

            //BossHealthSlider.value = currentHealth;

            if (currentHealth <= 0)
            {
                EnemyAudioManager.instance.Play("Enemy", "Death", gameObject);
                GetComponent<Collider2D>().enabled = false;
                //destroyanim.SetBool("isdestroy", true);
                //StartCoroutine(time());
                Destroy(Turret);
                GetComponent<BossLegsDeath>().enabled = true;
            }
        }


        if (currentHealth <= 250)
        {
            Turret.GetComponent<BossBulletSingle>().enabled = false;
            Turret.GetComponent<BossSpreadShooting>().enabled = true;
        }
    }

}
