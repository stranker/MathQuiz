using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traslator : Transformator {

    public int valor;
    public Vector3 vectorTraslacion;
    public LayerMask layerForma;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CambiarVectorEje();
        if (Input.GetKeyDown(KeyCode.E))
            valor++;
        else if (Input.GetKeyDown(KeyCode.Q))
            valor--;
    }

    public override void Transformate(GameObject forma)
    {
        forma.transform.GetComponent<Forma>().Traslate(vectorTraslacion * valor);
    }


    private void CambiarVectorEje()
    {
        switch (GetEje())
        {
            case 0:
                vectorTraslacion = new Vector3(1.0f, 0.0f, 0.0f);
                break;
            case 1:
                vectorTraslacion = new Vector3(0.0f, 1.0f, 0.0f);
                break;
            case 2:
                vectorTraslacion = new Vector3(0.0f, 0.0f, 1.0f);
                break;
            default:
                break;
        }
    }
}
