using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transperency : MonoBehaviour {

    [SerializeField]
    private float r = 1, g = 1, b = 1, Alpha = 1, decreaseA = 1;

    // Update is called once per frame
    void Update () {
        Alpha -= decreaseA * Time.deltaTime;
        GetComponent<SpriteRenderer>().color = new Color(r, g, b, Alpha);
    }
}
