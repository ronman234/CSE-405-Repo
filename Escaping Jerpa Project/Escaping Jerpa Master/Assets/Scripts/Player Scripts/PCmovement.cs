using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//player movement

public class PCmovement : MonoBehaviour
{

    [SerializeField]
    private float speed;

    public Joystick joystick;

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        //Physics2D.IgnoreLayerCollision(10, 1);  //ignore collision with objects in layers 10 and 1
    }

    void Move()
    {
        

        if (Input.GetKey(KeyCode.W) || (Input.GetAxis("Vertical") > 0) || (joystick.Vertical > 0))
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            
        }

        if (Input.GetKey(KeyCode.S) || (Input.GetAxis("Vertical") < 0) || (joystick.Vertical < 0))
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A) || (Input.GetAxis("Horizontal") < 0) || (joystick.Horizontal < 0))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D) || (Input.GetAxis("Horizontal") > 0) || (joystick.Horizontal > 0))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

    }
}
