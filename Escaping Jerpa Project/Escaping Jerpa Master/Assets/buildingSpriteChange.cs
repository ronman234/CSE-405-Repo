using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//chooses a sprite for a building object when it spawns

public class buildingSpriteChange : MonoBehaviour
{

    [SerializeField]
    private Sprite[] buildings; //array of sprites for the buildings

    [SerializeField]
    private float color;    //set shade of building color, 0 = darkest, 1 - lightest

    [SerializeField]
    private float alpha;    //set transperancy, 1 = no transperancy, 0 = full transperancy

    [SerializeField]
    private float scale;    //set size of object, 1 = default size

    private int chooseSprite;   //number that picks sprite

    // Use this for initialization
    void Start()
    {
        chooseSprite = Random.Range(0, 5); //pick a random number within the array, number decides what sprite to render
        if (chooseSprite == 3)
        {
            GetComponent<SpriteRenderer>().color = new Color(.2f, .2f, .2f, alpha);
        }
        else
            GetComponent<SpriteRenderer>().color = new Color(color, color, color, alpha);   //set color and transperancy of object

        transform.localScale = new Vector3(scale, scale, scale);    //set scale of object

        //set sprite based on 'chooseSprite' number
        this.gameObject.GetComponent<SpriteRenderer>().sprite = buildings[chooseSprite];
    }
}
