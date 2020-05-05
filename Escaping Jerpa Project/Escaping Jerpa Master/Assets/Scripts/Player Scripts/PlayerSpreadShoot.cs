using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpreadShoot : MonoBehaviour {

    public Transform firePoint; //point where bullet spawns
    public GameObject bulletPrefab; //bullet object

    public Button fireButton;

    private void Start()
    {
        Button btn = fireButton.gameObject.GetComponent<Button>();
        btn.onClick.AddListener(SpreadShoot);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetButtonDown("Fire1")) 
        {
            AudioManager.instance.Play("Player", "SpreadShot", gameObject);
            SpreadShoot();
        }

    }

    private Quaternion AngleConverter(float angle)
    {
        Quaternion bulletAngle = transform.rotation;
        bulletAngle.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + angle);
        return bulletAngle;
    }
    void SpreadShoot()
    {
        AudioManager.instance.Play("Player", "SpreadShot", gameObject);
        Instantiate(bulletPrefab, firePoint.position, AngleConverter(15.0f));   //spawn enemy bullet
        Instantiate(bulletPrefab, firePoint.position, AngleConverter(30.0f));
        Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        Instantiate(bulletPrefab, firePoint.position, AngleConverter(-15.0f));
        Instantiate(bulletPrefab, firePoint.position, AngleConverter(-30.0f));
    }
}
