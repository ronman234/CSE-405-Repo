using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechShot : MonoBehaviour {


    [SerializeField]
    private Animator laserShooting;

    private float lasertimer = 5;

    void Start()
    {
        laserShooting.SetBool("isShooting", true);
    }

    // Update is called once per frame
    void Update () {

        lasertimer -= Time.deltaTime;
        if (lasertimer <= 4 && lasertimer > .8f)
        {
            GetComponent<Collider2D>().enabled = true;
        }
        else GetComponent<Collider2D>().enabled = false;


    }
}
