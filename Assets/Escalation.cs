using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escalation : Transformations
{
    public override void SetPoints()
    {
        pos1 = ShapeManager.Get().transform.localScale;
        toPos = pos1;
        switch (axis)
        {
            case 0:
                toPos = new Vector3(toPos.x + value, toPos.y, toPos.z);
                break;
            case 1:
                toPos = new Vector3(toPos.x, toPos.y + value, toPos.z);
                break;
            case 2:
                toPos = new Vector3(toPos.x, toPos.y, toPos.z + value);
                break;
        }
    }
    public override void Transformate()
    {
        if (timer <= time)
        {
            switch (axis)
            {
                case 0:
                    ShapeManager.Get().transform.localScale = new Vector3(Mathf.Lerp(pos1.x, toPos.x, ac.Evaluate(timer / time)), pos1.y, pos1.z);
                    break;
                case 1:                    
                    ShapeManager.Get().transform.localScale = new Vector3(pos1.x, Mathf.Lerp(pos1.y, toPos.y, ac.Evaluate(timer / time)), pos1.z);
                    break;
                case 2:                    
                    ShapeManager.Get().transform.localScale = new Vector3(pos1.x, pos1.y, Mathf.Lerp(pos1.z, toPos.z, ac.Evaluate(timer / time)));
                    break;
            }
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0.0f;
            running = false;
        }
    }
}
