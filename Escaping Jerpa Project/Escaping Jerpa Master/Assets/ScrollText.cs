using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollText : MonoBehaviour
{
    [SerializeField]
    private float timer;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float skipTimer;

    private bool isMoving = true;

    public Button skipBtn;

    private void Start()
    {
        Button btn = skipBtn.gameObject.GetComponent<Button>();
        btn.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                isMoving = false;
            }
            MoveText(Vector2.up);
        }
        skipTimer -= Time.deltaTime;
        if (skipTimer <= 0)
            skipBtn.gameObject.SetActive(true);
    }

    void MoveText(Vector2 direction)
    {
        gameObject.transform.Translate(direction * speed * Time.deltaTime);
    }
}


