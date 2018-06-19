using System.Collections.Generic;
using UnityEngine;

public class Transformacion : MonoBehaviour
{
    public float valor;
    private bool isRunning;

    public virtual void Execute(GameObject forma)
    {
        isRunning = true;
    }

    public float GetValor()
    {
        return valor;
    }

    public bool IsRunning()
    {
        return isRunning;
    }

    public void SetRunning(bool val)
    {
        isRunning = val;
    }

}
