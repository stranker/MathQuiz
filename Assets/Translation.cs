using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translation : Transformations
{
    public override void SetPoints()
    {
        pos1 = ShapeManager.Get().transform.position;        
        switch (axis)
        {
            case 0:
                toPos = ShapeManager.Get().transform.right;
                break;
            case 1:
                toPos = ShapeManager.Get().transform.up;
                break;
            case 2:
                toPos = ShapeManager.Get().transform.forward;
                break;
            default:
                break;
        }
        toPos = toPos * value + pos1;        
    }
    public override void Transformate()
    {        
        if (timer <= time)
        {
            Debug.Log(timer);
            ShapeManager.Get().transform.position = Vector3.Lerp(pos1, toPos, ac.Evaluate(timer / time));
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0.0f;
            running = false;
        }
    }
}
