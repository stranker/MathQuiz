using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RutinasEscalator : Transformator2
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
            value++;
        else if (Input.GetKeyDown(KeyCode.Q))
            value--;
    }
    public override void Transformate()
    {
        switch (eje)
        {
            case 0:
                ShapeManager.Get().AddCommand(ScaleInX(value, ac, totalTime));
                break;
            case 1:
                ShapeManager.Get().AddCommand(ScaleInY(value, ac, totalTime));
                break;
            case 2:
                ShapeManager.Get().AddCommand(ScaleInZ(value, ac, totalTime));
                break;
        }
    }

    /// <summary>
    /// Transición desde un scale a otro siguiendo un transform
    /// </summary>
    /// <param name="posScale1"> Scale Inicial </param>
    /// <param name="posScale2"> Scale Final </param>
    /// <param name="ac"> Curva de animacion de tiempo </param>
    /// <param name="time"> Tiempo total de la transición </param>
    /// <returns></returns>
    IEnumerator Scale(Vector3 posScale2, AnimationCurve ac, float time)
    {
        Vector3 posScale1 = ShapeManager.Get().transform.localScale;

        while (timer <= time)
        {
            ShapeManager.Get().transform.localScale = Vector3.Lerp(posScale1, posScale2, ac.Evaluate(timer / time));
            timer += Time.deltaTime;
            yield return null;
        }        
        timer = 0.0f;
    }

    /// <summary>
    /// Scale en X
    /// </summary>
    /// <param name="posScale1"> Scale Inicial </param>
    /// <param name="value"> Valor a escalar </param>
    /// <param name="ac"> Curva de animacion de tiempo </param>
    /// <param name="time"> Tiempo total de la transición </param>
    /// <returns></returns>
    /// 
    IEnumerator ScaleInX(int value, AnimationCurve ac, float time)
    {
        Vector3 posScale1 = ShapeManager.Get().transform.localScale;
        Vector3 toPos = posScale1;
        toPos = new Vector3(toPos.x + value, toPos.y, toPos.z);

        while (timer <= time)
        {
            ShapeManager.Get().transform.localScale = new Vector3(Mathf.Lerp(posScale1.x, toPos.x, ac.Evaluate(timer / time)), posScale1.y, posScale1.z);
            timer += Time.deltaTime;
            yield return null;
        }        
        timer = 0.0f;
    }

    /// <summary>
    /// Scale en Y
    /// </summary>
    /// <param name="posScale1"> Scale Inicial </param>
    /// <param name="value"> Valor a escalar </param>
    /// <param name="ac"> Curva de animacion de tiempo </param>
    /// <param name="time"> Tiempo total de la transición </param>
    /// <returns></returns>    
    IEnumerator ScaleInY(int value, AnimationCurve ac, float time)
    {
        Vector3 posScale1 = ShapeManager.Get().transform.localScale;
        Vector3 toPos = posScale1;
        toPos = new Vector3(toPos.x, toPos.y + value, toPos.z);

        while (timer <= time)
        {
            ShapeManager.Get().transform.localScale = new Vector3(posScale1.x, Mathf.Lerp(posScale1.y, toPos.y, ac.Evaluate(timer / time)), posScale1.z);
            timer += Time.deltaTime;
            yield return null;
        }        
        timer = 0.0f;
    }

    /// <summary>
    /// Scale en Z
    /// </summary>
    /// <param name="posScale1"> Scale Inicial </param>
    /// <param name="value"> Valor a escalar </param>
    /// <param name="ac"> Curva de animacion de tiempo </param>
    /// <param name="time"> Tiempo total de la transición </param>
    /// <returns></returns>    
    IEnumerator ScaleInZ(int value, AnimationCurve ac, float time)
    {
        Vector3 posScale1 = ShapeManager.Get().transform.localScale;
        Vector3 toPos = posScale1;
        toPos = new Vector3(toPos.x, toPos.y, toPos.z + value);

        while (timer <= time)
        {
            ShapeManager.Get().transform.localScale = new Vector3(posScale1.x, posScale1.y, Mathf.Lerp(posScale1.z, toPos.z, ac.Evaluate(timer / time)));
            timer += Time.deltaTime;
            yield return null;
        }        
        timer = 0.0f;
    }
}
