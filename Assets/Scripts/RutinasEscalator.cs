using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RutinasEscalator : Transformator
{
    public AnimationCurve ac;
    public int maxValue;
    private float totalTime;
    private float timer;
    private float t;
    private void Start()
    {
        totalTime = ShapeManager.Get().GetTime();
        timer = 0;
        t = 0;
    }

    private void Update()
    {
        Inputs();
    }
    private void Inputs()
    {
        if (Input.GetKey(KeyCode.E))
            if (value < maxValue)
                if (t > 0.1f)
                {
                    value++;
                    t = 0;
                }
                else
                    t += Time.deltaTime;
            else
                value = maxValue;
        else if (Input.GetKey(KeyCode.Q))
            if (value > -maxValue)
                if (t > 0.1f)
                {
                    value--;
                    t = 0;
                }
                else
                    t += Time.deltaTime;
            else
                value = -maxValue;
    }
    public override void Transformate()
    {
               // ShapeManager.Get().AddCommand(ScaleInAxis(eje,value, ac, totalTime));
    }

    IEnumerator ScaleInAxis(int eje, int value, AnimationCurve ac, float time)
    {
        Vector3 posScale1 = ShapeManager.Get().transform.localScale;
        Vector3 toPos = posScale1;
        switch (eje)
        {
            case 0:
                toPos = new Vector3(toPos.x + value, toPos.y, toPos.z);
                break;
            case 1:
                toPos = new Vector3(toPos.x, toPos.y + value, toPos.z);
                break;
            case 2:
                toPos = new Vector3(toPos.x, toPos.y, toPos.z + value);
                break;
        }
        while (timer <= time)
        {
            switch (eje)
            {
                case 0:
                    ShapeManager.Get().transform.localScale = new Vector3(Mathf.Lerp(posScale1.x, toPos.x, ac.Evaluate(timer / time)), posScale1.y, posScale1.z);
                    break;
                case 1:
                    toPos = new Vector3(toPos.x, toPos.y + value, toPos.z);
                    ShapeManager.Get().transform.localScale = new Vector3(posScale1.x, Mathf.Lerp(posScale1.y, toPos.y, ac.Evaluate(timer / time)), posScale1.z);
                    break;
                case 2:
                    toPos = new Vector3(toPos.x, toPos.y, toPos.z + value);
                    ShapeManager.Get().transform.localScale = new Vector3(posScale1.x, posScale1.y, Mathf.Lerp(posScale1.z, toPos.z, ac.Evaluate(timer / time)));
                    break;
            }
            timer += Time.deltaTime;
            yield return null;
        }
        timer = 0.0f;
    }
}
