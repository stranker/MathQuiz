using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NOSE : MonoBehaviour
{

    public AnimationCurve ac;
    private float timer;
    private float value;
    private float time;
    private bool running;
    private Vector3 pos1;
    private Vector3 toPos;
    private void Start()
    {
        running = false;
        timer = 0;
        value = 5;
        time = 3;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && !running)
        {
            Debug.Log("HOLA");
            running = true;
            pos1  = transform.position;
            toPos = pos1 + transform.right * value;                        
        }
        if (running)
        {
            if (timer <= time)
            {
                transform.position = Vector3.Lerp(pos1, toPos, ac.Evaluate(timer / time));
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0.0f;
                running = false;
            }
        }
    }
}
