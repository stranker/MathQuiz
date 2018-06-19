using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traslator : Transformator
{
    public GameObject traslatePrefab;

    // Use this for initialization
    void Start()
    {
    }

    public override void Transformate(GameObject forma)
    {
        GameObject traslation = Instantiate(traslatePrefab, forma.transform);
        traslation.GetComponent<Traslation>().Create(forma, valor, eje);
        forma.GetComponent<Forma>().AddTransform(traslation.GetComponent<Traslation>());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            valor++;
        else if (Input.GetKeyDown(KeyCode.Q))
            valor--;
    }
}