using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//spawn the default bullet from player default wep fire point


public class DefaultWep : MonoBehaviour {

    public Transform firePoint; //point where bullet spawns
    public GameObject bulletPrefab; //bullet object

    public Button fireButton;
    public bool firing = false;
    private void Start()
    {
        Button btn = fireButton.gameObject.GetComponent<Button>();
        //btn.onClick.AddListener(Shoot);
    }

    // Update is called once per frame
    void Update () {
		
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetButtonDown("Fire1") || firing)
        {
            AudioManager.instance.Play("Player","BasicAttack", gameObject);
            Shoot();
        }
	}

    public void Shoot()
    {
        //AudioManager.instance.Play("Player", "BasicAttack", gameObject);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        firing = false;
    }

    public void Fire()
    {
        firing = true;
    }

}

