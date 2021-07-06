using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDestory : MonoBehaviour {

    private float startTime;
    
	void Start () 
	{
        startTime = Time.fixedTime;
	}
	void Update () 
	{
		if (Time.fixedTime - startTime >= 3) 
		{
			Destroy(gameObject); 
		}
	}
}
