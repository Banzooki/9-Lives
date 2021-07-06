using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScene : MonoBehaviour 
{
	[SerializeField] private Text WinTitle;
	void Start () 
	{
		WinTitle.alignment = TextAnchor.UpperCenter;
		WinTitle.text = "Congratulations\n You Survived\n With " + GlobalVar.health + " Lives left\n And scored " + GlobalVar.score;
	}
}