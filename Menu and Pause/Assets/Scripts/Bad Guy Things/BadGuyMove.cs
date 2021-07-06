using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyMove : MonoBehaviour {

	public float speed = 0.2f; // This sets the speed for the bad guy that I want them to move
	public bool MoveLeft = true; // A boolean to check if the sprite is moving left
	private SpriteRenderer SpriteRenderer; // This will render the sprite so that it can be seen by the player and can be interacted by the player 
	void Start () 
	{
		SpriteRenderer = GetComponent<SpriteRenderer> (); // This calls the sprite render and initialises it
    }

	void Update () 
	{
		if (MoveLeft) { // standared if statment to see if move left is true or false
			transform.position += Vector3.left * speed; // move the sprite left by muliplying the vecotr 3 by the speed intager 
        } else { // if the statment above  
			transform.position += Vector3.right * speed; // moves the sprite right by muliplying the vecotr 3 by the speed intager 
		}
		if (transform.position.x < 3.6) // this if checks to see if the dogs position is below a certain vale and then fips the sprite and it moves right
		{
			MoveLeft = false;
			SpriteRenderer.flipX = true;
		}
		if (transform.position.x > 5.4) // this if checks to see if the dogs position is above a certain vale and then fips the sprite and it moves left
        {
			MoveLeft = true;
			SpriteRenderer.flipX = false;
		}
	}
}