using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormaManager : MonoBehaviour
{
    public GameObject[] shapes;
    int countShapes;
    private void Start()
    {
        foreach (GameObject forma in shapes)
        {
            forma.GetComponent<Forma>().ShapeInPosition += DeactivateShape;
        }
        countShapes = shapes.Length;        
    }
    private void DeactivateShape(GameObject shape)
    {        
        countShapes--;
        AllInPosition();
    }
    private void AllInPosition()
    {
        if (countShapes == 0)
            GameManager.Get().Win();
    }    
}
