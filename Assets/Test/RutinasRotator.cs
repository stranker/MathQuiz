using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RutinasRotator : Transformator2
{

    private float totalTime;    
    public AnimationCurve ac;    
    private float timer;

    private void Start()
    {
        totalTime = ShapeManager.Get().GetTime();
        timer = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            value += 45;
        else if (Input.GetKeyDown(KeyCode.Q))
            value -= 45;
    }
    public override void Transformate()
    {
        switch (eje)
        {
            case 0:
                ShapeManager.Get().AddCommand(RotateInX(value, ac, totalTime));
                break;
            case 1:
                ShapeManager.Get().AddCommand(RotateInY(value, ac, totalTime));
                break;
            case 2:
                ShapeManager.Get().AddCommand(RotateInZ(value, ac, totalTime));
                break;
        }
    }

    /// <summary>
    /// Rotación siguiendo la rotación de un gameObject
    /// </summary>
    /// <param name="pos1"> Posición Inicial </param>
    /// <param name="pos2"> Posición Final </param>
    /// <param name="ac"> Curva de animación de tiempo </param>
    /// <param name="time"> Tiempo total de la transición </param>
    /// <returns></returns>
    IEnumerator Rotate(Quaternion pos2, AnimationCurve ac, float time)
    {
        Quaternion pos1 = ShapeManager.Get().transform.rotation;
        while (timer <= time)
        {
            ShapeManager.Get().transform.rotation = Quaternion.Lerp(pos1, pos2, ac.Evaluate(timer / time));
            timer += Time.deltaTime;
            yield return null;
        }
        timer = 0.0f;
    }


    /// <summary>
    /// Rotación en X
    /// </summary>
    /// <param name="pos1"> Posición Inicial </param>
    /// <param name="value"> Valor a sumar </param>
    /// <param name="ac"> Curva de animación de tiempo </param>
    /// <param name="time"> Tiempo total de la transición </param>
    /// <returns></returns>
    IEnumerator RotateInX(int value, AnimationCurve ac, float time)
    {
        Vector3 pos1 = ShapeManager.Get().transform.eulerAngles;
        Vector3 toPos = pos1;
        toPos = new Vector3(toPos.x + value, toPos.y, toPos.z);

        while (timer <= time)
        {
            ShapeManager.Get().transform.eulerAngles = new Vector3(Mathf.Lerp(pos1.x, toPos.x, ac.Evaluate(timer / time)), toPos.y, toPos.z);
            timer += Time.deltaTime;
            yield return null;
        }
        timer = 0.0f;
    }

    /// <summary>
    /// Rotación en Y
    /// </summary>
    /// <param name="pos1"> Posición Inicial </param>
    /// <param name="value"> Valor a sumar </param>
    /// <param name="ac"> Curva de animación de tiempo </param>
    /// <param name="time"> Tiempo total de la transición </param>
    /// <returns></returns>
    IEnumerator RotateInY(int value, AnimationCurve ac, float time)
    {
        Vector3 pos1 = ShapeManager.Get().transform.eulerAngles;
        Vector3 toPos = pos1;
        toPos = new Vector3(toPos.x, toPos.y + value, toPos.z);

        while (timer <= time)
        {
            ShapeManager.Get().transform.eulerAngles = new Vector3(toPos.x, Mathf.Lerp(pos1.y, toPos.y, ac.Evaluate(timer / time)), toPos.z);
            timer += Time.deltaTime;
            yield return null;
        }
        timer = 0.0f;
    }

    /// <summary>
    /// Rotación en Z
    /// </summary>
    /// <param name="pos1"> Posición Inicial </param>
    /// <param name="value"> Valor a sumar </param>
    /// <param name="ac"> Curva de animación de tiempo </param>
    /// <param name="time"> Tiempo total de la transición </param>
    /// <returns></returns>
    IEnumerator RotateInZ(int value, AnimationCurve ac, float time)
    {
        Vector3 pos1 = ShapeManager.Get().transform.eulerAngles;
        Vector3 toPos = pos1;
        toPos = new Vector3(toPos.x, toPos.y, toPos.z + value);

        while (timer <= time)
        {
            ShapeManager.Get().transform.eulerAngles = new Vector3(toPos.x, toPos.y, Mathf.Lerp(pos1.z, toPos.z, ac.Evaluate(timer / time)));
            timer += Time.deltaTime;
            yield return null;
        }
        timer = 0.0f;
    }
}
