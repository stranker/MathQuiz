﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : Transformator {

    public int valor;
    public Vector3 vectorRotacion;
    public LayerMask layerForma;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        CambiarVectorEje();
        if (Input.GetKeyDown(KeyCode.E))
            valor += 15;
        else if (Input.GetKeyDown(KeyCode.Q))
            valor -= 15;
    }

    public override void Transformate(GameObject forma)
    {
        forma.transform.GetComponent<Forma>().Rotate(vectorRotacion * valor);
    }

    private void CambiarVectorEje()
    {
        switch (GetEje())
        {
            case 0:
                vectorRotacion = new Vector3(1.0f, 0.0f, 0.0f);
                break;
            case 1:
                vectorRotacion = new Vector3(0.0f, 1.0f, 0.0f);
                break;
            case 2:
                vectorRotacion = new Vector3(0.0f, 0.0f, 1.0f);
                break;
            default:
                break;
        }
    }
}
