using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traslator : Transformator
{

    public Vector3 vectorTraslacion;
    public LayerMask layerForma;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            valor++;
        else if (Input.GetKeyDown(KeyCode.Q))
            valor--;
    }

    public override void Transformate(GameObject forma)
    {
        forma.transform.GetComponent<Forma>().Traslate(valor, GetEje());
    }
}