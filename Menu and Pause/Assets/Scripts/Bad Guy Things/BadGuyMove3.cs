using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyMove3 : MonoBehaviour {

	public float speed = 0.2f;
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
		if (transform.position.x < -3.2) 
		{
			MoveLeft = false;
			SpriteRenderer.flipX = true;
		}
		if (transform.position.x > 2.7) 
		{
			MoveLeft = true;
			SpriteRenderer.flipX = false;
		}
	}
}