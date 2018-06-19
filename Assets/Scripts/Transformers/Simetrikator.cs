using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simetrikator : Transformator {

    public Vector3 vectorTraslacion;
    public Vector3 ejeSimetria;
    public LayerMask layerForma;

    // Use this for initialization
    void Start()
    {
        vectorTraslacion = new Vector3(0.0f, -1.0f, 0.0f);
        ejeSimetria = new Vector3(1.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        CambiarVectorEje();
    }

    public override void Transformate(GameObject forma)
    {
    }

    private void CambiarVectorEje()
    {
        switch (GetEje())
        {
            case 0:
                ejeSimetria = new Vector3(1.0f, 0.0f, 0.0f);
                vectorTraslacion = new Vector3(0.0f, -1.0f, 0.0f);
                break;
            case 1:
                ejeSimetria = new Vector3(0.0f, 1.0f, 0.0f);
                vectorTraslacion = new Vector3(-1.0f, 0.0f, 0.0f);
                break;
            case 2:
                ejeSimetria = new Vector3(0.0f, 0.0f, 1.0f);
                vectorTraslacion = new Vector3(0.0f, 0.0f, -1.0f);
                break;
            default:
                break;
        }
    }
}
