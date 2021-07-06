using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notDamgePowerup : MonoBehaviour 
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "cat")
        {
			GlobalVar.notDamageMode = true;
			GlobalVar.notDamageModeStartTime = Time.time;
            Destroy(gameObject);

        }
    }
}