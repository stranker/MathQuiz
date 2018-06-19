using System.Collections;
using UnityEngine;

public class Traslation : Transformacion
{
    public GameObject forma;
    public Vector3 initialPos;
    public Vector3 endPos;
    public AnimationCurve ac;
    public float totalTime;
    public float timer;

    private void Start()
    {
        timer = 0;
    }

    public override void Create(GameObject _forma, int value, int axis)
    {
        forma = _forma;
        initialPos = forma.transform.position;
        switch (axis)
        {
            case 0:
                endPos = initialPos + forma.transform.right * value;
                break;
            case 1:
                endPos = initialPos + forma.transform.up * value;
                break;
            case 2:
                endPos = initialPos + forma.transform.forward * value;
                break;
            default:
                break;
        }
    }

    private void Update()
    {
        if (IsRunning())
        {
            if (timer <= totalTime)
            {
                Vector3 position = Vector3.Lerp(initialPos, endPos, ac.Evaluate(timer / totalTime));
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

        SetRunning(true);
    }
}

