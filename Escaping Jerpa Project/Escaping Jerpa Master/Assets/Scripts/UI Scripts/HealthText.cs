using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{
    private Text healthText;
    private Slider health;

	// Use this for initialization
	void Start ()
    {
        health = gameObject.GetComponentInParent<Slider>();
        healthText = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        healthText.text = health.value.ToString() + " / 100";
	}
}
