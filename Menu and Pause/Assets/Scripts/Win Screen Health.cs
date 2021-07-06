using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreenHealth : MonoBehaviour {
	[SerializeField] private Text WinTitle;
	void Start () 
	{
		WinTitle.text = "Congratulations You Win With " + GlobalVar.health + " Lives";
	}
}
