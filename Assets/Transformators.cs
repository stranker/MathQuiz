using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transformators : MonoBehaviour
{
    public GameObject transformationCommand;

    enum EJE
    {
        X,
        Y,
        Z,
        LAST
    }

    public AnimationCurve ac;
    public int maxValue;
    public int addValue;

    protected float totalTime;
    protected int axis;
    protected int value;
    protected float timer;
    protected float t;

    private void Start()
    {
        totalTime = ShapeManager.Get().GetTime();
    }

    private void Update()
    {
        Inputs();
    }
    private void Inputs()
    {
        if (Input.GetKey(KeyCode.E))
            if (value < maxValue)
                if (t > 0.1f)
                {
                    value += addValue;
                    t = 0;
                }
                else
                    t += Time.deltaTime;
            else
                value = maxValue;
        else if (Input.GetKey(KeyCode.Q))
            if (value > -maxValue)
                if (t > 0.1f)
                {
                    value -= addValue;
                    t = 0;
                }
                else
                    t += Time.deltaTime;
            else
                value = -maxValue;
    }

    abstract public void Transformate();

    public void NextEje()
    {
        axis++;
        axis = axis % (int)EJE.LAST;
    }
    public int GetEje()
    {
        return axis;
    }
    public float GetValor()
    {
        return value;
    }
}
