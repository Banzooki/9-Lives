using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class movement2 : MonoBehaviour
{

    public float speed = 1.5f; //This sets the speed of the sprites speed to be 5
    private SpriteRenderer SpriteRenderer; //This makes sure that the spire gets assigned the variable 'SpriteRenderer'
    [SerializeField] private Text healthLabel;

    void Start() //This is what happens when the code is first launched
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        transform.position = new Vector3(-8.1f, -4.3f, -5.0f); //Sets the position of the spirte to these coordinates
        healthLabel.text = "Health: " + GlobalVar.health;

    }

    void Update() //This section of the code will activate when a certain criteria is met
    {
        if (Input.GetKey(KeyCode.LeftArrow)) //This section contains the 'if' statements which control the movement of the players sprite
        {
            if (transform.position.x > -8.1)//Sets the boundary for when the left arrow is pressed
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
                SpriteRenderer.flipX = true;//This sets the X axis to be fliped when the left arrow is pressed
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //if (transform.position.x < 20.1)//Sets the boundary for when the right arrow is pressed
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
                SpriteRenderer.flipX = false;//This sets the X axis to be set to normal when the right arrow is pressed
            }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (transform.position.y < 4.3)//Sets the boundary for when the up arrow is pressed
            {
                transform.position += Vector3.up * speed * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (transform.position.y > -4.3)//Sets the boundary for when the down arrow is pressed
            {
                transform.position += Vector3.down * speed * Time.deltaTime;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
		if (col.gameObject.tag == "enemy") {
			GlobalVar.health--;
			healthLabel.text = "Health: " + GlobalVar.health;
  
			if (GlobalVar.health == 0) {
				GlobalVar.health = 9;
				SceneManager.LoadScene (4);
			}
		}
		else if (col.gameObject.tag == "flag") 
		{
			SceneManager.LoadScene (5);
		}
	}
}


