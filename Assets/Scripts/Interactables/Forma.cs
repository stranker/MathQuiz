using System.Collections.Generic;
using UnityEngine;

public class Forma : MonoBehaviour {

    public string name;
    public Canvas display;
    public int severity;
    public List<Transformacion> transformationList;
    public Vector3 initialPosition;
    public Vector3 initialRotation;

    private void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.eulerAngles;
        EndDisplay();
    }

    public void AddTransform(Transformacion trans)
    {
        transformationList.Add(trans);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            ExecuteTransforms();
        if (Input.GetKeyDown(KeyCode.Backspace))
            ResetForma();
    }

    public void DisplayInfo()
    {        
        display.GetComponent<FormaDisplay>().SetInformation(gameObject);
        display.GetComponent<FormaDisplay>().StartDisplay();
    }

    public void EndDisplay()
    {        
        display.GetComponent<FormaDisplay>().EndDisplay();
    }

    public void ExecuteTransforms()
    {
        if (transformationList.Count > 0)
            transformationList[0].Execute(gameObject);
        else
            Debug.Log("DONE");
    }

    public void RemoveTransform()
    {
        transformationList.RemoveAt(0);
        ExecuteTransforms();
    }

    public void ResetForma()
    {
        transform.position = initialPosition;
        transform.eulerAngles = initialRotation;
        foreach (Transformacion trans in transformationList)
            trans.SetRunning(false);
        transformationList.Clear();
    }
}
