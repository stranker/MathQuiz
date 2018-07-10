using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormaManager : MonoBehaviour
{
    public GameObject[] shapes;
    public GameObject spaceship;
    int countShapes;

    private void Start()
    {
        foreach (GameObject forma in shapes)
        {
            forma.GetComponent<Forma>().ShapeInPosition += DeactivateShape;
        }
        countShapes = shapes.Length;        
    }


    private void Update()
    {
        OnFinalButton();
    }

    private void DeactivateShape(GameObject shape)
    {        
        countShapes--;
        AllInPosition();
    }

    private void AllInPosition()
    {
        if (countShapes == 0)
        {
            spaceship.GetComponent<Spaceship>().StartEngine();
            GameManager.Get().Win();
        }
    }

    public void OnFinalButton()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            foreach (GameObject shape in shapes)
            {
                shape.GetComponent<Forma>().GoToFinal();
            }
            countShapes = 0;
            AllInPosition();
        }

    }

}
