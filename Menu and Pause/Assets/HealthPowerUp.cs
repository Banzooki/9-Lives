using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthPowerUp : MonoBehaviour 
{
	void Update () 
	{
		
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "cat") 
		{
			GlobalVar.health = (Mathf.Min (GlobalVar.health + 1, 9));
			GlobalVar.score = GlobalVar.score + 500;
            GlobalVar.time = GlobalVar.time + 200;
			Destroy (gameObject);
		}

	}
}
