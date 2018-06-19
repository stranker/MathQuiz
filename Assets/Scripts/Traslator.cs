using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traslator : Transformator
{
    public GameObject traslatePrefab;
    public LayerMask layerForma;

    // Use this for initialization
    void Start()
    {
    }

    public override void Transformate(GameObject forma)
    {
        Traslation traslation = Instantiate(traslatePrefab, transform).GetComponent<Traslation>();
        traslation.Create(forma,value,eje);
        forma.GetComponent<Forma>().AddTransform(traslation);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            value++;
        else if (Input.GetKeyDown(KeyCode.Q))
            value--;
    }
}