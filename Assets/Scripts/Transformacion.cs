﻿using System.Collections.Generic;
using UnityEngine;

public class Transformacion : MonoBehaviour
{

    public GameObject forma;
    public Vector3 initialAttribute;
    public Vector3 endAttribute;
    public AnimationCurve ac;
    public float totalTime;
    public float timer;
    private bool isRunning;
    public int axis;
    public int value;

    public virtual void Execute(GameObject forma)
    {
        isRunning = true;
    }

    public virtual void Create(GameObject _forma, int _value, int eje)
    {
        forma = _forma;
        value = _value;
        axis = eje;
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
