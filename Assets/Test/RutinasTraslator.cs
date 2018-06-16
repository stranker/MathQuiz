using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RutinasTraslator : Transformator2
{
    private float totalTime;    
    public AnimationCurve ac;
    public int maxValue;
    private float t;
    private float timer;

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
        switch (eje)
        {
            case 0:
                ShapeManager.Get().AddCommand(MoveInX(value, ac, totalTime));
                break;
            case 1:
                ShapeManager.Get().AddCommand(MoveInY(value, ac, totalTime));
                break;
            case 2:
                ShapeManager.Get().AddCommand(MoveInZ(value, ac, totalTime));
                break;
        }
    }
    
    /// <summary>
    /// Moverse en X
    /// </summary>
    /// <param name="pos1"> Posición Inicial </param>
    /// <param name="value"> Valor a moverse </param>
    /// <param name="ac"> Curva de animacion de tiempo </param>
    /// <param name="time"> Tiempo total de la transición </param>
    /// <returns></returns>
    IEnumerator MoveInX(int value, AnimationCurve ac, float time)
    {        
        Vector3 pos1 = ShapeManager.Get().transform.position;
        Vector3 toPos = ShapeManager.Get().transform.right;
        toPos *= value;
        toPos += pos1;

        while (timer <= time)
        {
            ShapeManager.Get().transform.position = Vector3.Lerp(pos1, toPos, ac.Evaluate(timer / time));           
            timer += Time.deltaTime;
            yield return null;
        }
        timer = 0.0f;
    }

    /// <summary>
    /// Moverse en Y
    /// </summary>
    /// <param name="pos1"> Posición Inicial </param>
    /// <param name="value"> Valor a moverse </param>
    /// <param name="ac"> Curva de animacion de tiempo </param>
    /// <param name="time"> Tiempo total de la transición </param>
    /// <returns></returns>    
    IEnumerator MoveInY(int value, AnimationCurve ac, float time)
    {        
        Vector3 pos1 = ShapeManager.Get().transform.position;
        Vector3 toPos = ShapeManager.Get().transform.up;
        toPos *= value;
        toPos += pos1;

        while (timer <= time)
        {
            ShapeManager.Get().transform.position = Vector3.Lerp(pos1, toPos, ac.Evaluate(timer / time));
            timer += Time.deltaTime;
            yield return null;
        }
        timer = 0.0f;
    }

    /// <summary>
    /// Moverse en Z
    /// </summary>
    /// <param name="pos1"> Posición Inicial </param>
    /// <param name="value"> Valor a moverse </param>
    /// <param name="ac"> Curva de animacion de tiempo </param>
    /// <param name="time"> Tiempo total de la transición </param>
    /// <returns></returns>    
    IEnumerator MoveInZ(int value, AnimationCurve ac, float time)
    {        
        Vector3 pos1 = ShapeManager.Get().transform.position;
        Vector3 toPos = ShapeManager.Get().transform.forward;
        toPos *= value;
        toPos += pos1;

        while (timer <= time)
        {
            ShapeManager.Get().transform.position = Vector3.Lerp(pos1, toPos, ac.Evaluate(timer / time));
            timer += Time.deltaTime;
            yield return null;
        }
        timer = 0.0f;
    }
}

