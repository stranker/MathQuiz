﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaleitor : Transformator {

    public GameObject mira;
    public float valor;
    public Vector3 vectorEscalacion;
    public LayerMask layerForma;

    // Use this for initialization
    void Start()
    {
        vectorEscalacion = new Vector3(1.0f, 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        CambiarVectorEje();
        if (Input.GetKey(KeyCode.E) || Input.mouseScrollDelta.y > 0)
            valor += 0.1f;
        else if (Input.GetKey(KeyCode.Q) || Input.mouseScrollDelta.y < 0)
            valor -= 0.1f;
    }

    override public void Transformate(GameObject forma)
    {
        forma.GetComponent<Forma>().Scale(vectorEscalacion * valor);
    }

    private void CambiarVectorEje()
    {
        switch (GetEje())
        {
            case 0:
                vectorEscalacion = new Vector3(1.0f, 0.0f, 0.0f);
                break;
            case 1:
                vectorEscalacion = new Vector3(0.0f, 1.0f, 0.0f);
                break;
            case 2:
                vectorEscalacion = new Vector3(0.0f, 0.0f, 1.0f);
                break;
            default:
                break;
        }
    }

}
