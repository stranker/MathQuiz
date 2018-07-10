using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour {

    public int speed = 5;
    public bool completed = false;

    private void Update()
    {
        if(completed)
            transform.position += transform.up * Time.deltaTime * speed;
    }

    public void StartEngine()
    {
        completed = true;
    }
}
