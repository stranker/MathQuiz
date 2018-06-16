using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rutinasEscalator : MonoBehaviour
{
    public float totalTime;
    public Transform endPos;
    public AnimationCurve ac;
    public int toX;

    private bool isRunning;
    private float timer;

    private void Start()
    {
        timer = 0;
        isRunning = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (!isRunning)
                StartCoroutine(Scale(transform.localScale, endPos.localScale, ac, totalTime));
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (!isRunning)
                StartCoroutine(ScaleInX(transform.localScale, toX, ac, totalTime));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (!isRunning)
                StartCoroutine(ScaleInY(transform.localScale, toX, ac, totalTime));
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (!isRunning)
                StartCoroutine(ScaleInZ(transform.position, toX, ac, totalTime));
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
    IEnumerator Scale(Vector3 posScale1, Vector3 posScale2, AnimationCurve ac, float time)
    {
        isRunning = true;
        while (timer <= time)
        {
            transform.localScale = Vector3.Lerp(posScale1, posScale2, ac.Evaluate(timer / time));
            timer += Time.deltaTime;
            yield return null;
        }
        isRunning = false;
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
    IEnumerator ScaleInX(Vector3 posScale1, int value, AnimationCurve ac, float time)
    {
        isRunning = true;
        Vector3 toPos = posScale1;
        toPos = new Vector3(toPos.x + value, toPos.y, toPos.z);

        while (timer <= time)
        {
            transform.localScale = new Vector3(Mathf.Lerp(posScale1.x, toPos.x, ac.Evaluate(timer / time)), transform.localScale.y, transform.localScale.z);
            timer += Time.deltaTime;
            yield return null;
        }
        isRunning = false;
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
    IEnumerator ScaleInY(Vector3 posScale1, int value, AnimationCurve ac, float time)
    {
        isRunning = true;
        Vector3 toPos = posScale1;
        toPos = new Vector3(toPos.x, toPos.y + value, toPos.z);

        while (timer <= time)
        {
            transform.localScale = new Vector3(transform.localScale.x, Mathf.Lerp(posScale1.y, toPos.y, ac.Evaluate(timer / time)), transform.localScale.z);
            timer += Time.deltaTime;
            yield return null;
        }
        isRunning = false;
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
    IEnumerator ScaleInZ(Vector3 posScale1, int value, AnimationCurve ac, float time)
    {
        isRunning = true;
        Vector3 toPos = posScale1;
        toPos = new Vector3(toPos.x, toPos.y, toPos.z + value);

        while (timer <= time)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, Mathf.Lerp(posScale1.z, toPos.z, ac.Evaluate(timer / time)));
            timer += Time.deltaTime;
            yield return null;
        }
        isRunning = false;
        timer = 0.0f;
    }
}
