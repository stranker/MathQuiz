using System.Collections.Generic;
using UnityEngine;

public class Transformacion : MonoBehaviour
{
    private bool isRunning;

    public virtual void Execute(GameObject forma)
    {
        isRunning = true;
    }

    public virtual void Create(GameObject forma, int value, int eje)
    {

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
