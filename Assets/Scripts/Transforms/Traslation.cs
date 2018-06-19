using System.Collections;
using UnityEngine;

public class Traslation : Transformacion
{

    private void Start()
    {
        timer = 0;
    }

    public override void Create(GameObject _forma, int val, int eje)
    {
        base.Create(_forma, val, eje);
        initialAttribute = forma.transform.position;
        switch (axis)
        {
            case 0:
                endAttribute = initialAttribute + forma.transform.right * value;
                break;
            case 1:
                endAttribute = initialAttribute + forma.transform.up * value;
                break;
            case 2:
                endAttribute = initialAttribute + forma.transform.forward * value;
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
                Vector3 position = Vector3.Lerp(initialAttribute, endAttribute, ac.Evaluate(timer / totalTime));
                forma.transform.position = position;
                timer += Time.deltaTime;
            }
            else
            {
                SetRunning(false);
                timer = 0.0f;
                forma.GetComponent<Forma>().RemoveTransform();
                Destroy(gameObject);
            }
        }
    }

    public override void Execute(GameObject _forma)
    {
        Create(_forma, value, axis);
        SetRunning(true);
    }
}

