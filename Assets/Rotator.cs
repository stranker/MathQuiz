using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : Transformators
{
    public override void Transformate()
    {
        GameObject command = Instantiate(transformationCommand);
        Transformations t = command.GetComponent<Transformations>();
        t.SetValues(axis, value, ac, totalTime);
        ShapeManager.Get().AddCommand(command);
    }
}
