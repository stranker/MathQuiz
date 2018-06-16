using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Transformator2 : MonoBehaviour
{
    enum EJE
    {
        X,
        Y,
        Z,
        LAST
    }
    public int eje;
    public int value;

    public void NextEje()
    {
        eje++;
        eje = eje % (int)EJE.LAST;
    }

    abstract public void Transformate();

    public int GetEje()
    {
        return eje;
    }

    public float GetValor()
    {
        return value;
    }
}
