using System.Collections.Generic;
using UnityEngine;

public class Transformacion : MonoBehaviour
{
    enum TYPE {TRASLATE, ROTATE, SYMMETRY, SCALE};
    public int typeOfTransform;
    public float valor;

    public void CreateTransform(int type, float _valor)
    {
        typeOfTransform = type;
        valor = _valor;
    }

    public int GetTypeTraslate()
    {
        return (int)TYPE.TRASLATE;
    }

    public int GetTypeRotate()
    {
        return (int)TYPE.ROTATE;
    }

    public int GetTypeSymmetry()
    {
        return (int)TYPE.SYMMETRY;
    }

    public int GetTypeScale()
    {
        return (int)TYPE.SCALE;
    }

    public float GetValor()
    {
        return valor;
    }

}
