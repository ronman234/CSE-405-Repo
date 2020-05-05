using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    public GameObject mainMenu;
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Circle"))
        {
            mainMenu.SetActive(true);
            gameObject.SetActive(false);
        }
	}
}
