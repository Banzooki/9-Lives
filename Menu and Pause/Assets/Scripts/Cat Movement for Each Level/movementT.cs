using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GlobalVar
{
    static public int health = 9;
	static public int score = 0;
    static public int time = 3000;
    static public float speed = 5; //This sets the speed of the sprites speed to be 5
	static public bool speedMode = false;
	static public float speedModeStartTime;
	static public bool notDamageMode = false;
	static public float notDamageModeStartTime;
}

public class movementT : MonoBehaviour
{
	private bool moveRight = false;
	private bool moveLeft = false;
    public bool moveUp = false;
    public int jumpSpeed = 5;
	private string catState = "Idle";

    private SpriteRenderer SpriteRenderer; //This makes sure that the spire gets assigned the variable 'SpriteRenderer'

    [SerializeField] private Text healthLabel;
	[SerializeField] private Text scoreLabel;
    [SerializeField] private Text timeLabel;
    [SerializeField] private Text powerupLabel;

    void showScore(int theScore)
	{
		scoreLabel.text = "Score: " + theScore;
	}

	void showLives(int theLives)
	{
		healthLabel.text = "Lives: " + theLives;
	}
    void showTime(int theTime)
    {
        timeLabel.text = "Time: " + theTime/100;
    }
	void showPowerUp(int theMode)
	{
		if (theMode == 0)
			powerupLabel.text = "";
		else
			powerupLabel.text = "Power-Up Time Left: " + theMode;
	}

    void Start() //This is what happens when the code is first launched
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();

		switch (SceneManager.GetActiveScene().buildIndex)
		{
		case 5:
			transform.position = new Vector3(-6.7f,  1.725f, -5.0f);
			break;
		default:
		transform.position = new Vector3(-8.1f, -4.3f, -5.0f); //Sets the position of the spirte to these coordinates
			break;
		}

		showLives (GlobalVar.health);
		showScore (GlobalVar.score);
    }

	void Update() //This section of the code will activate when a certain criteria is met
	{
		if (GlobalVar.speedMode && Time.time - GlobalVar.speedModeStartTime > 5) 
		{
			GlobalVar.speedMode = false;
			GlobalVar.speed = 5;
		}
		if (GlobalVar.notDamageMode && Time.time - GlobalVar.notDamageModeStartTime > 5) 
		{
			GlobalVar.notDamageMode = false;
		}
			
		if ((moveLeft = Input.GetKey (KeyCode.LeftArrow))) {  //This section contains the 'if' statements which control the movement of the players sprite
			transform.position += Vector3.left * GlobalVar.speed * Time.deltaTime;
			SpriteRenderer.flipX = (catState == "Jump");//This sets the X axis to be fliped when the left arrow is pressed
			if (catState != "Jump")
				catState = "Walk";
			//GetComponent<Animator> ().Play ("WalkCat");
		}

		if ((moveRight = Input.GetKey (KeyCode.RightArrow))) {
			transform.position += Vector3.right * GlobalVar.speed * Time.deltaTime;
			SpriteRenderer.flipX = (catState != "Jump");//This sets the X axis to be set to normal when the right arrow is pressed
			if (catState != "Jump")
				catState = "Walk";
			//GetComponent<Animator> ().Play ("WalkCat");
		}

		if (Input.GetKey (KeyCode.UpArrow) ) {
			if (transform.position.y < 4.3) { //Sets the boundary for when the up arrow is pressed
				Debug.Log("Jump Cat");
				transform.position += Vector3.up * jumpSpeed * Time.deltaTime;
				catState = "Jump";
				//GetComponent<Animator> ().Play ("JumpCat");
			}
		}

		if (Input.GetKey (KeyCode.DownArrow)) {
			if (transform.position.y > -4.3) //Sets the boundary for when the down arrow is pressed
				transform.position += Vector3.down * jumpSpeed * Time.deltaTime;
			//catState = "Fall";
		}
		if (!moveRight && !moveLeft &&  catState != "Jump") {
			catState = "Idle";
		}

		switch (catState) {
		case "Idle":
			GetComponent<Animator> ().Play ("IdleCat");
			break;
		case "Walk":
			GetComponent<Animator> ().Play ("WalkCat");
			break;
            case "Jump":
                GetComponent<Animator>().Play("JumpCatAngle");
			break;
		default:
			GetComponent<Animator> ().Play ("IdleCat");
			Debug.Log ("Unknow Cat State");
			break;
		}

		if (GlobalVar.speedMode)
			showPowerUp (5 - (int)(Time.time - GlobalVar.speedModeStartTime));
		else if (GlobalVar.notDamageMode)
			showPowerUp (5 - (int)(Time.time - GlobalVar.notDamageModeStartTime));
		else
			showPowerUp (0);

		if (moveRight)
			showScore (++GlobalVar.score);
		if (moveLeft) 
			showScore(GlobalVar.score = Mathf.Max(GlobalVar.score - 1, 0));
        if (GlobalVar.time == 0)
            SceneManager.LoadScene(4);
        showLives (GlobalVar.health);
		showScore (GlobalVar.score);
        showTime(GlobalVar.time = Mathf.Max(GlobalVar.time -1, 0));
        GlobalVar.time--;
    }


	void OnCollisionEnter2D(Collision2D col)
    {
		
		if (col.gameObject.tag == "enemy") 
		{
			if (!GlobalVar.notDamageMode) 
			{
				showLives (--GlobalVar.health);
				showScore ((GlobalVar.score = Mathf.Max (GlobalVar.score - 100, 0)));
			
				if (GlobalVar.health == 0) {
					GlobalVar.health = 9;
					GlobalVar.score = 0;
					SceneManager.LoadScene (4);
				}
			}
		} else if (col.gameObject.tag == "flag") {
			switch (SceneManager.GetActiveScene ().buildIndex) {
			case 1:
				SceneManager.LoadScene (5);
				GlobalVar.score = GlobalVar.score + GlobalVar.time;
				GlobalVar.time = 3000;
                    
				break;
			case 5:
				SceneManager.LoadScene (6);
				GlobalVar.score = GlobalVar.score + GlobalVar.time;
				GlobalVar.time = 3000;
				break;
			case 6:
				SceneManager.LoadScene (7);
				GlobalVar.score = GlobalVar.score + GlobalVar.time;
				GlobalVar.time = 3000;
				break;
			default:
				GlobalVar.health = 9;
				GlobalVar.score = 0;
				GlobalVar.time = 3000;
				SceneManager.LoadScene (1);
				break;
			}
		} else
			catState = "Idle";
	}
}