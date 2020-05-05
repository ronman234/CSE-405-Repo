using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodge : MonoBehaviour {


    private bool dodge = true;

    [SerializeField]
    private float dodgetime = .65f, dodgeCooldown = 1.25f;

    void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }

    // Update is called once per frame
    void Update () {
        if ((Input.GetKey(KeyCode.Space) || Input.GetButtonDown("Square") && dodge))
        {
            GetComponent<trailEcho>().enabled = true;
            GetComponent<Collider2D>().enabled = false;
            dodge = false;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .25f);
            StartCoroutine(time());
        }
        
    }

    public void Dodge()
    {
        GetComponent<trailEcho>().enabled = true;
        GetComponent<Collider2D>().enabled = false;
        dodge = false;
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .25f);
        StartCoroutine(time());
    }

    IEnumerator time()
    {
        yield return new WaitForSeconds(dodgetime);
        GetComponent<Collider2D>().enabled = true;
        GetComponent<trailEcho>().enabled = false;
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        StartCoroutine(cooldown());

    }

    IEnumerator cooldown()
    {
        yield return new WaitForSeconds(dodgeCooldown);
        dodge = true;

    }
}
