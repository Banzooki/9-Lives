using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyMove5 : MonoBehaviour {

	public float speed = 0.01f;
	public bool MoveLeft = true;
	private SpriteRenderer SpriteRenderer;
	void Start () 
	{
		SpriteRenderer = GetComponent<SpriteRenderer> ();
	}

	void Update () 
	{
		if (MoveLeft) {
			transform.position += Vector3.left * speed;
		} else {
			transform.position += Vector3.right * speed;
		}
		if (transform.position.x < 25.1) 
		{
			MoveLeft = false;
			SpriteRenderer.flipX = true;
		}
		if (transform.position.x > 29.15) 
		{
			MoveLeft = true;
			SpriteRenderer.flipX = false;
		}
	}
}