using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : Transformator {

    public GameObject rotatePrefab;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E))
            valor += 15;
        else if (Input.GetKeyDown(KeyCode.Q))
            valor -= 15;
        if (valor > 360 || valor < -360)
            valor = 0;
    }

    public override void Transformate(GameObject forma)
    {
        GameObject rotate = Instantiate(rotatePrefab, forma.transform);
        rotate.GetComponent<Rotation>().Create(forma, valor, eje);
        forma.GetComponent<Forma>().AddTransform(rotate.GetComponent<Rotation>());
    }
}
