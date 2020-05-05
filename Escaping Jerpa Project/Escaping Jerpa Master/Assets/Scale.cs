using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour {

    [SerializeField]
    private float scaling;
    
    private float scaledSize = 4;
	
	// Update is called once per frame
	void Update () {
        scaledSize -= Random.Range(2f,5f) * Time.deltaTime;
        transform.localScale = new Vector3(scaledSize, scaledSize, scaledSize);
        if (scaledSize <= 0)
        {
            scaledSize = 0;
        }
	}
}
