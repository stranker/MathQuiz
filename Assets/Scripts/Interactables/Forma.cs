using System.Collections.Generic;
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
    public GameObject EndPosition;

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
            DisableShape();
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
        if ((transform.position == EndPosition.transform.position) && (transform.eulerAngles == EndPosition.transform.eulerAngles) && (transform.localScale == EndPosition.transform.localScale))
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
    public Vector3 GetEndPosition()
    {
        return EndPosition.transform.position;
    }
    private void DisableShape()
    {
        display.transform.gameObject.SetActive(false);
        EndPosition.transform.gameObject.SetActive(false);
        this.enabled = false;
    }
}
