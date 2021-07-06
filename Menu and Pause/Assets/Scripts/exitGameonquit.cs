using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitGameonquit : MonoBehaviour {

	public void exit()
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.quit();
		#endif
	}
}