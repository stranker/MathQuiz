using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RutinasRotator : Transformator
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
                    value += 45;
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
                    value -= 45;
                    t = 0;
                }
                else
                    t += Time.deltaTime;
            else
                value = -maxValue;
    }
    public override void Transformate()
    {
        //ShapeManager.Get().AddCommand(RotateInAxis(eje, value, ac, totalTime));
    }

    /// <summary>
    /// Rotación en X
    /// </summary>
    /// <param name="pos1"> Posición Inicial </param>
    /// <param name="value"> Valor a sumar </param>
    /// <param name="ac"> Curva de animación de tiempo </param>
    /// <param name="time"> Tiempo total de la transición </param>
    /// <returns></returns>
    IEnumerator RotateInAxis(int eje, int value, AnimationCurve ac, float time)
    {
        Vector3 pos1 = ShapeManager.Get().transform.eulerAngles;
        Vector3 toPos = pos1;
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
                    ShapeManager.Get().transform.eulerAngles = new Vector3(Mathf.Lerp(pos1.x, toPos.x, ac.Evaluate(timer / time)), toPos.y, toPos.z);
                    break;
                case 1:
                    ShapeManager.Get().transform.eulerAngles = new Vector3(toPos.x, Mathf.Lerp(pos1.y, toPos.y, ac.Evaluate(timer / time)), toPos.z);
                    break;
                case 2:
                    ShapeManager.Get().transform.eulerAngles = new Vector3(toPos.x, toPos.y, Mathf.Lerp(pos1.z, toPos.z, ac.Evaluate(timer / time)));
                    break;
            }
            timer += Time.deltaTime;
            yield return null;
        }
        timer = 0.0f;
    }
}
