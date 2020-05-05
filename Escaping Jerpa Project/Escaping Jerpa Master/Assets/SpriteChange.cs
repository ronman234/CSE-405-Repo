using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChange : MonoBehaviour {

    //chooses sprite, color, and scale for civilian car objects

    [SerializeField]
    private Sprite[] civCarSprites; //array for car sprites

    private int chooseSprite;   //number that chooses which sprite to render

	// Use this for initialization
	void Start () {
        chooseSprite = Random.Range(1, 10); //number 1 through 9

        GetComponent<SpriteRenderer>().color = new Color(.6f, .6f, .6f, 1);   //sets color and transperancy

        //5 is set to render the truck sprite
        if (chooseSprite == 5)  
            transform.localScale = new Vector3(1.75f, 1.75f, 1.75f); //makes the truck sprite larger than the other sprites
        else transform.localScale = new Vector3(.7f, .7f, .7f); //makes the civilian car sprite half as big if not truck sprite
    }

    void Update()
    {
        //renders a sprite based on the number of 'chooseSprite'
        if (chooseSprite < 5)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = civCarSprites[0];
        }
        else if (chooseSprite > 5)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = civCarSprites[1];
        }
        else if (chooseSprite == 5)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = civCarSprites[2];
        }

    }

}
