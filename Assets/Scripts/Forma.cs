using System.Collections.Generic;
using UnityEngine;

public class Forma : MonoBehaviour {

    public GameObject transformacion;
    public List<Transformacion> transformationList;

    private void Start()
    {
        AddTransform(transformacion.GetComponent<Transformacion>());
    }

    public void AddTransform(Transformacion trans)
    {
        transformationList.Add(trans);
    }

    private void Update()
    {
        ExecuteTransforms();
    }

    public void ExecuteTransforms()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (transformationList.Count > 0)
            {
                transformationList[0].Execute(gameObject);
            }
        }
    }

    public void RemoveTransform(Transformacion trans)
    {
        transformationList.Remove(trans);
    }

}
