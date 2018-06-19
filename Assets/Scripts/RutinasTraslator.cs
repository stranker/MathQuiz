using System.Collections;
using UnityEngine;

public class RutinasTraslator : Transformacion
{
    public GameObject forma;
    public Vector3 endPos;
    public AnimationCurve ac;
    public float totalTime;
    public float timer;
    public Vector3 position;

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
                position = Vector3.Lerp(forma.transform.position, endPos, ac.Evaluate(timer / totalTime));
                forma.transform.position = position;
                timer += Time.deltaTime;
            }
            else
            {
                SetRunning(false);
                timer = 0.0f;
                forma.GetComponent<Forma>().RemoveTransform(this);
                Destroy(gameObject);
            }
        }
    }

    public override void Execute(GameObject _forma)
    {
        forma = _forma;
        SetRunning(true);
    }
}

