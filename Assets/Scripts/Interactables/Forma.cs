﻿using System.Collections.Generic;
using UnityEngine;

public class Forma : MonoBehaviour
{

    public delegate void ShapeActions(GameObject shape);
    public ShapeActions ShapeInPosition;

    public string name;
    public Canvas display;
    public int severity;
    public List<Transformacion> transformationList;
    public Vector3 initialPosition;
    public Vector3 initialRotation;
    public Vector3 EndPosition;
    public Vector3 EndRotation;
    public Vector3 EndScalation;

    private bool executing;

    private void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.eulerAngles;
        EndDisplay();
        executing = false;
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
        else if (executing && EndPositionsOK())
        {
            ShapeInPosition(gameObject);
            executing = false;
        }
        else
            Debug.Log("notwin");
    }

    public void RemoveTransform()
    {
        transformationList.RemoveAt(0);
        executing = true;
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
    private bool EndPositionsOK()
    {
        RoundToInt();
        Debug.Log(EndPosition);
        Debug.Log(EndRotation);
        Debug.Log(EndScalation);
        if ((transform.position == EndPosition) && (transform.eulerAngles == EndRotation) && (transform.localScale == EndScalation))
        {
            return true;
        }
        else
            return false;
    }
    private void RoundToInt()
    {
        transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.z));
        transform.eulerAngles = new Vector3(Mathf.RoundToInt(transform.eulerAngles.x), Mathf.RoundToInt(transform.eulerAngles.y), Mathf.RoundToInt(transform.eulerAngles.z));
        transform.localScale = new Vector3(Mathf.RoundToInt(transform.localScale.x), Mathf.RoundToInt(transform.localScale.y), Mathf.RoundToInt(transform.localScale.z));
    }
}
