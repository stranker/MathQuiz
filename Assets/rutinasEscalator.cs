using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rutinasEscalator : MonoBehaviour
{
    private float totalTime;
    public Transform endPos;
    public AnimationCurve ac;
    public int toX;    
    private float timer;

    private void Start()
    {
        totalTime = ShapeManager.Get().GetTime();
        timer = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            ShapeManager.Get().AddCommand(Scale(endPos.localScale, ac, totalTime));
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

            ShapeManager.Get().AddCommand(ScaleInX(toX, ac, totalTime));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            ShapeManager.Get().AddCommand(ScaleInY(toX, ac, totalTime));
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ShapeManager.Get().AddCommand(ScaleInZ(toX, ac, totalTime));
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
            transform.localScale = Vector3.Lerp(posScale1, posScale2, ac.Evaluate(timer / time));
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
            transform.localScale = new Vector3(Mathf.Lerp(posScale1.x, toPos.x, ac.Evaluate(timer / time)), transform.localScale.y, transform.localScale.z);
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
            transform.localScale = new Vector3(transform.localScale.x, Mathf.Lerp(posScale1.y, toPos.y, ac.Evaluate(timer / time)), transform.localScale.z);
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
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, Mathf.Lerp(posScale1.z, toPos.z, ac.Evaluate(timer / time)));
            timer += Time.deltaTime;
            yield return null;
        }        
        timer = 0.0f;
    }
}
