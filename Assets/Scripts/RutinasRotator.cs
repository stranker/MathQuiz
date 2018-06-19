using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RutinasRotator : Transformacion
{
    public GameObject forma;
    public Quaternion endRotation;
    public AnimationCurve ac;
    public float totalTime;
    public float timer;

    private void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        if (IsRunning())
        {
            if (timer <= totalTime)
            {
                Quaternion rotation = Quaternion.Lerp(forma.transform.rotation, endRotation, ac.Evaluate(timer / totalTime));
                forma.transform.rotation = rotation;
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0.0f;
                SetRunning(false);
            }
        }
    }

    public override void Execute(GameObject _forma)
    {
        forma = _forma;
        SetRunning(true);
    }
}
