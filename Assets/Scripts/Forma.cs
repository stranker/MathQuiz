using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forma : MonoBehaviour {

    public void Rotate(Vector3 rotacion)
    {
        transform.Rotate(rotacion);
    }

    public void Traslate(float valor,int eje)
    {        
        switch (eje)
        {
            case 0:
                transform.position += transform.right * valor;
                break;
            case 1:
                transform.position += transform.up * valor;
                break;
            case 2:
                transform.position += transform.forward * valor;
                break;
        }
    }

    public void Symmetry(Vector3 ejeSimetria, Vector3 vectorTraslacion)
    {
        transform.position = new Vector3(transform.position.x * vectorTraslacion.x,
            transform.position.y * vectorTraslacion.y, transform.position.z * vectorTraslacion.z);
        transform.Rotate(ejeSimetria,180);
    }

    public void Scale(Vector3 escalacion)
    {
        if (escalacion.x != 0)
            transform.localScale = new Vector3(escalacion.x, transform.localScale.y, transform.localScale.z);
        else if (escalacion.y != 0)
            transform.localScale = new Vector3(transform.localScale.x, escalacion.y, transform.localScale.z);
        else if (escalacion.z != 0)
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, escalacion.z);
    }
}
