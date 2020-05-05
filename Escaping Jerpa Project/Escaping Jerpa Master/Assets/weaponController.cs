using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponController : MonoBehaviour
{
    public bool powerBool = false;
    public bool aBombBool = false;
    public float timer;
    private aBombShoot bomb;

    public Button fire1;
    public Button fire2;
    public Button bombbtn;
   
	// Use this for initialization
	void Start ()
    {
        GetComponent<PlayerSpreadShoot>().enabled = false;
        bomb = GetComponent<aBombShoot>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (powerBool)
        {
            GetComponent<PlayerSpreadShoot>().enabled = true;
            GetComponent<DefaultWep>().enabled = false;
            fire1.gameObject.SetActive(false);
            fire2.gameObject.SetActive(true);

            timer -= Time.deltaTime;
            if (timer < 0)
            {
                powerBool = false;
                timer = 0;
            }
        }
        else
        {
            GetComponent<PlayerSpreadShoot>().enabled = false;
            GetComponent<DefaultWep>().enabled = true;
            fire1.gameObject.SetActive(true);
            fire2.gameObject.SetActive(false);
        }
        
        if (aBombBool)
        {
            bombbtn.gameObject.SetActive(false);
            bomb.enabled = true;
        }
        else
        {
            bombbtn.gameObject.SetActive(false);
            bomb.enabled = false;
        }

    }

    void OnCollisionEnter2D (Collision2D coll)
    {
        if (coll.gameObject.tag == "powerup")
        {
            Debug.Log("Powered Up");
            powerBool = true;
        }
    }
}
