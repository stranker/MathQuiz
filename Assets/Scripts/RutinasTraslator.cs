using System.Collections;
using UnityEngine;

public class RutinasTraslator : Transformacion
{
    public float totalTime;
    public GameObject forma;
    public Vector3 endPos;
    public AnimationCurve ac;
    public int toX;
    private float timer;

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
                Vector3 position = Vector3.Lerp(forma.transform.position, endPos, ac.Evaluate(timer / totalTime));
                forma.transform.position = position;
                timer += Time.deltaTime;
            }
            else
            {
                SetRunning(false);
                timer = 0.0f;
            }
        }
    }

    public override void Execute(GameObject _forma)
    {
        forma = _forma;
        SetRunning(true);
    }
}

