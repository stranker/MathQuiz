using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RutinasTraslator : MonoBehaviour
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
                StartCoroutine(Move(transform.position, endPos.position, ac, totalTime));
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (!isRunning)
                StartCoroutine(MoveInX(transform.position, toX, ac, totalTime));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (!isRunning)
                StartCoroutine(MoveInY(transform.position, toX, ac, totalTime));
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (!isRunning)
                StartCoroutine(MoveInZ(transform.position, toX, ac, totalTime));
        }
    }

    /// <summary>
    /// Transición desde un punto a otro siguiendo un transform
    /// </summary>
    /// <param name="pos1"> Posición Inicial </param>
    /// <param name="pos2"> Posicion Final </param>
    /// <param name="ac"> Curva de animacion de tiempo </param>
    /// <param name="time"> Tiempo total de la transición </param>
    /// <returns></returns>
    IEnumerator Move(Vector3 pos1, Vector3 pos2, AnimationCurve ac, float time)
    {
        isRunning = true;
        while (timer <= time)
        {
            transform.position = Vector3.Lerp(pos1, pos2, ac.Evaluate(timer / time));
            timer += Time.deltaTime;
            yield return null;
        }
        isRunning = false;
        timer = 0.0f;
    }

    /// <summary>
    /// Moverse en X
    /// </summary>
    /// <param name="pos1"> Posición Inicial </param>
    /// <param name="value"> Valor a moverse </param>
    /// <param name="ac"> Curva de animacion de tiempo </param>
    /// <param name="time"> Tiempo total de la transición </param>
    /// <returns></returns>
    IEnumerator MoveInX(Vector3 pos1, int value, AnimationCurve ac, float time)
    {
        isRunning = true;
        Vector3 toPos = pos1;
        toPos = new Vector3(toPos.x + value, toPos.y, toPos.z);

        while (timer <= time)
        {
            transform.position = new Vector3(Mathf.Lerp(pos1.x, toPos.x, ac.Evaluate(timer / time)), transform.position.y, transform.position.z);
            timer += Time.deltaTime;
            yield return null;
        }
        isRunning = false;
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
    IEnumerator MoveInY(Vector3 pos1, int value, AnimationCurve ac, float time)
    {
        isRunning = true;
        Vector3 toPos = pos1;
        toPos = new Vector3(toPos.x, toPos.y + value, toPos.z);

        while (timer <= time)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(pos1.y, toPos.y, ac.Evaluate(timer / time)), transform.position.z);
            timer += Time.deltaTime;
            yield return null;
        }
        isRunning = false;
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
    IEnumerator MoveInZ(Vector3 pos1, int value, AnimationCurve ac, float time)
    {
        isRunning = true;
        Vector3 toPos = pos1;
        toPos = new Vector3(toPos.x,toPos.y,toPos.z+value);

        while (timer <= time)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y, Mathf.Lerp(pos1.z, toPos.z, ac.Evaluate(timer / time)));
            timer += Time.deltaTime;
            yield return null;
        }
        isRunning = false;
        timer = 0.0f;
    }
}

