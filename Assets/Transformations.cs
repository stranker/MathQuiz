using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transformations : MonoBehaviour
{

    protected int axis;
    protected bool running;
    protected int value;
    protected AnimationCurve ac;
    protected float time;
    protected float timer;
    protected Vector3 pos1;
    protected Vector3 toPos;

    private void Start()
    {
        running = false;
        axis = 0;
        value = 0;
        ac = null;
        timer = 0;
    }

    private void Update()
    {
        if (running)
        {            
            Transformate();
        }
    }

    public void Play()
    {
        SetPoints();
        running = true;
    }
    public void SetValues(int _axis, int _value, AnimationCurve _ac, float _time)
    {
        axis = _axis;
        value = _value;
        ac = _ac;
        time = _time;
    }

    public abstract void Transformate();
    public abstract void SetPoints();

    public void Stop()
    {
        running = false;
    }
}
