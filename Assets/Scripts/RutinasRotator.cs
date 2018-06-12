using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RutinasRotator : MonoBehaviour
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
                StartCoroutine(Rotate(transform.rotation, endPos.rotation, ac, totalTime));
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (!isRunning)
                StartCoroutine(RotateInX(transform.eulerAngles, toX, ac, totalTime));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (!isRunning)
                StartCoroutine(RotateInY(transform.eulerAngles, toX, ac, totalTime));
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (!isRunning)
                StartCoroutine(RotateInZ(transform.eulerAngles, toX, ac, totalTime));
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
    IEnumerator Rotate(Quaternion pos1, Quaternion pos2, AnimationCurve ac, float time)
    {
        isRunning = true;
        while (timer <= time)
        {
            transform.rotation = Quaternion.Lerp(pos1, pos2, ac.Evaluate(timer / time));
            timer += Time.deltaTime;
            yield return null;
        }
        isRunning = false;
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
    IEnumerator RotateInX(Vector3 pos1, int value, AnimationCurve ac, float time)
    {
        isRunning = true;
        Vector3 toPos = pos1;
        toPos = new Vector3(toPos.x + value, toPos.y, toPos.z);

        while (timer <= time)
        {
            transform.eulerAngles = new Vector3(Mathf.Lerp(pos1.x, toPos.x, ac.Evaluate(timer / time)), toPos.y, toPos.z);
            timer += Time.deltaTime;
            yield return null;
        }
        isRunning = false;
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
    IEnumerator RotateInY(Vector3 pos1, int value, AnimationCurve ac, float time)
    {
        isRunning = true;
        Vector3 toPos = pos1;
        toPos = new Vector3(toPos.x , toPos.y + value, toPos.z);

        while (timer <= time)
        {
            transform.eulerAngles = new Vector3(toPos.x, Mathf.Lerp(pos1.y, toPos.y, ac.Evaluate(timer / time)), toPos.z);
            timer += Time.deltaTime;
            yield return null;
        }
        isRunning = false;
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
    IEnumerator RotateInZ(Vector3 pos1, int value, AnimationCurve ac, float time)
    {
        isRunning = true;
        Vector3 toPos = pos1;
        toPos = new Vector3(toPos.x, toPos.y, toPos.z + value);

        while (timer <= time)
        {
            transform.eulerAngles = new Vector3(toPos.x, toPos.y, Mathf.Lerp(pos1.z, toPos.z, ac.Evaluate(timer / time)));
            timer += Time.deltaTime;
            yield return null;
        }
        isRunning = false;
        timer = 0.0f;
    }
}
