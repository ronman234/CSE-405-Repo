using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{

    public float y;

    //public Transform target;
    //private Vector3 v_diff;
    //private float atan2;

    //private Rigidbody boss;
    //private float translateY = 0.0f;

    //private float counter;

    public float upperYBound = 1f;
    public float lowerYBound = -1f;
    public float middleBound = 0f;

    void Start()
    {
        y = transform.position.y;
    }

    void Update()
    {
        y += Time.deltaTime;
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
        if (y >= 2.5f)
        {
            Strafing();
        }

        //Rotation();

        //counter += 1f;
    }

    /*void Rotation()
    {
        v_diff = (target.position - transform.position);
        atan2 = Mathf.Atan2(v_diff.x, v_diff.y);
        transform.rotation = Quaternion.Euler(0f, 0f, -atan2 * Mathf.Rad2Deg);

        //Restrict rotations
        float minRotation = 80;
        float maxRotation = 100;

        Vector3 currentRotation = transform.localRotation.eulerAngles;
        currentRotation.z = Mathf.Clamp(currentRotation.z, minRotation, maxRotation);
        transform.localRotation = Quaternion.Euler(currentRotation);
    }*/

    void Strafing()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(upperYBound, lowerYBound, middleBound), transform.position.z);

        middleBound += 1f * Time.deltaTime;

        if (middleBound > 1f)
        {
            float newYBound = upperYBound;
            upperYBound = lowerYBound;
            lowerYBound = newYBound;
            middleBound = 0.0f;
        }

        //float yAxis = Mathf.Clamp(transform.position.y, 1f, -1f);
        //Restrict X-Axis
        //float xAxis = Mathf.Clamp(transform.position.x, 5.62f, 5.62f);
        //transform.position = new Vector3(xAxis, transform.position.y, transform.position.z);
    }
}