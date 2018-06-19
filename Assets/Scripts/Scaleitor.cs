using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaleitor : Transformator {

    public GameObject scalePrefab;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.mouseScrollDelta.y > 0)
            valor += 1;
        else if (Input.GetKeyDown(KeyCode.Q) || Input.mouseScrollDelta.y < 0)
            valor -= 1;
    }


    public override void Transformate(GameObject forma)
    {
        GameObject scale = Instantiate(scalePrefab, forma.transform);
        scale.GetComponent<Scale>().Create(forma, valor, eje);
        forma.GetComponent<Forma>().AddTransform(scale.GetComponent<Scale>());
    }
}
