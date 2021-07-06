using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseLeft : MonoBehaviour
{

    public int left = 1;
    public int speed = 5;
    void Update()
    {
        if (left == 1)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }
}