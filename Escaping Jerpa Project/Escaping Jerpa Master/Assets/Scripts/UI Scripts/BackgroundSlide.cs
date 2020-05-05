using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSlide : MonoBehaviour
{
    public float velocity;
    public float timer;
    private bool isMoving = false;
    private readonly float tempVelocity = 1.0f;
    private float startVelocity;

    private void Start()
    {
        startVelocity = velocity;
        if (isMoving == false)
        {
            velocity = tempVelocity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && isMoving == false)
        {
            isMoving = true;
            velocity = startVelocity;
        }
        if (isMoving)
        {
            MoveScreen(Vector2.left);

        }
    }
    void MoveScreen(Vector2 direction)
    {
        gameObject.transform.Translate(direction * velocity * Time.deltaTime);
    }
}
