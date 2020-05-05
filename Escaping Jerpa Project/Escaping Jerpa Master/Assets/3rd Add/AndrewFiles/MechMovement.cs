using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechMovement : MonoBehaviour
{
    private bool isfiring = true;

    [SerializeField]
    private Transform LaserFP;

    [SerializeField]
    private GameObject laserPrefab;

    [SerializeField]
    private float movementSpeed;    //enemy movement speed when spawned

    private Transform targetPlayer;

    [SerializeField]
    private float firstmovetime = 1;    //amount of time enemy moves when first spawned

    [SerializeField]
    private float follow = 3, firing = 5;   //amount of time enemy is stationary after firstmovetime reaches 0

    private float speed;

    //[SerializeField]
    //private Animator defcopanim;


    // Use this for initialization
    void Start()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        firstmovetime -= Time.deltaTime;

        //enemy moves while firstmovetime is greater than 0
        if (firstmovetime > 0)
        {
            moving();
        }
        else if (firstmovetime < 0)
        {
            follow -= Time.deltaTime;

            if (follow > 0)
            {
                followMovement();
            } else if (follow < 0 && (isfiring))
            {
                Instantiate(laserPrefab, LaserFP.position, LaserFP.rotation);
                isfiring = false;
            }
            else StartCoroutine(firingTime());

        }
        
    }

    //enemy moving while firstmovetime is not 0
    void moving()
    {
        transform.position += Vector3.left * movementSpeed * Time.deltaTime;
    }
  

    //enemy moves up offscreen
    void awaymovingup()
    {
        transform.position += Vector3.up * movementSpeed * Time.deltaTime;
        Destroy(gameObject, 5f);
    }

    void followMovement()
    {
        
        //enemy follows player's y axis only
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, targetPlayer.position.y), movementSpeed * Time.deltaTime);
        
    }

    IEnumerator firingTime()
    {
        yield return new WaitForSeconds(firing);
        
        awaymovingup();
    }
}

