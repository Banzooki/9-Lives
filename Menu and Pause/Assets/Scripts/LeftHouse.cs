using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHouse : MonoBehaviour
{
    public float speed = 1f; // This was the speed that I wanted the camera to move at
	public GameObject Cat;

	void Start()
	{
		Cat = GameObject.Find ("Cat"); 
	}

    void Update() // The main update function
    {
		if (Cat.transform.position.x > transform.position.x + 2 && transform.position.x < 41)
			transform.position += Vector3.right * speed * Time.deltaTime; // Moving the background and the camera to the right
		else if (Cat.transform.position.x < transform.position.x - 5 && transform.position.x > 0)
			transform.position += Vector3.left * speed * Time.deltaTime; // Moving the background and the camera to the right
    }
}