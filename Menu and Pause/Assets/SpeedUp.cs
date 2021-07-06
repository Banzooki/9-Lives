using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "cat")
        {
            GlobalVar.speed = 10;
			GlobalVar.speedMode = true;
			GlobalVar.speedModeStartTime = Time.time;
            Destroy(gameObject);

        }
    }
}
    