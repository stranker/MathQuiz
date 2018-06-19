using System.Collections.Generic;
using UnityEngine;

public class Forma : MonoBehaviour {

    public List<Transformacion> transformationList;

    private void Start()
    {
    }

    public void AddTransform(Transformacion trans)
    {
        transformationList.Add(trans);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
            ExecuteTransforms();
    }

    public void ExecuteTransforms()
    {
        if (transformationList.Count > 0)
            transformationList[0].Execute(gameObject);
        else
            Debug.Log("DONE");
    }

    public void RemoveTransform(Transformacion trans)
    {
        transformationList.Remove(trans);
        ExecuteTransforms();
    }

}
