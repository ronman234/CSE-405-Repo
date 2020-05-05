using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWhiteFlash : MonoBehaviour {

    private SpriteRenderer thisRender;
    private Shader whiteSprite;
    private Shader defaultColor;

    // Use this for initialization
    void Start()
    {
        thisRender = gameObject.GetComponent<SpriteRenderer>();
        whiteSprite = Shader.Find("GUI/Text Shader");
        defaultColor = Shader.Find("Sprites/Default");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "bulletcollide")
        {
            thisRender.material.shader = whiteSprite;
            thisRender.color = Color.white;
            StartCoroutine(flashTime());
        }
    }

    IEnumerator flashTime()
    {
        yield return new WaitForSeconds(.08f);
        thisRender.material.shader = defaultColor;
        thisRender.color = Color.white;
    }
}

