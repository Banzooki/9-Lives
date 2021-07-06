using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class startGameonclick : MonoBehaviour
{
	public void Loadbyindex (int Sceneindex)
	{
		GlobalVar.health = 9;
		GlobalVar.score = 0;
        GlobalVar.time = 3000;
		SceneManager.LoadScene (Sceneindex);
	}
}