using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RutinasTraslator : MonoBehaviour
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
            ShapeManager.Get().AddCommand(Move(endPos.position, ac, totalTime));
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ShapeManager.Get().AddCommand(MoveInX(toX, ac, totalTime));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ShapeManager.Get().AddCommand(MoveInY(toX, ac, totalTime));
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ShapeManager.Get().AddCommand(MoveInZ(toX, ac, totalTime));
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
    IEnumerator Move(Vector3 pos2, AnimationCurve ac, float time)
    {
        Vector3 pos1 = ShapeManager.Get().transform.position;

        while (timer <= time)
        {            
            transform.position = Vector3.Lerp(pos1, pos2, ac.Evaluate(timer / time));
            timer += Time.deltaTime;
            yield return null;
        }
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
    IEnumerator MoveInX(int value, AnimationCurve ac, float time)
    {
        Vector3 pos1 = ShapeManager.Get().transform.position;
        Vector3 toPos = pos1;
        toPos = new Vector3(toPos.x + value, toPos.y, toPos.z);

        while (timer <= time)
        {
            transform.position = new Vector3(Mathf.Lerp(pos1.x, toPos.x, ac.Evaluate(timer / time)), transform.position.y, transform.position.z);
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
        Vector3 toPos = pos1;
        toPos = new Vector3(toPos.x, toPos.y + value, toPos.z);

        while (timer <= time)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(pos1.y, toPos.y, ac.Evaluate(timer / time)), transform.position.z);
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
        Vector3 toPos = pos1;
        toPos = new Vector3(toPos.x,toPos.y,toPos.z+value);

        while (timer <= time)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y, Mathf.Lerp(pos1.z, toPos.z, ac.Evaluate(timer / time)));
            timer += Time.deltaTime;
            yield return null;
        }
        timer = 0.0f;
    }
}

