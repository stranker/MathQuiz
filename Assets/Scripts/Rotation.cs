using UnityEngine;

public class Rotation : Transformacion
{

    private void Start()
    {
    }

    public override void Create(GameObject forma, int value, int eje)
    {
        base.Create(forma, value, eje);
        initialAttribute = forma.transform.eulerAngles;
        switch (axis)
        {
            case 0:
                endAttribute = new Vector3(initialAttribute.x + value, initialAttribute.y, initialAttribute.z);
                break;
            case 1:
                endAttribute = new Vector3(initialAttribute.x, initialAttribute.y + value, initialAttribute.z);
                break;
            case 2:
                endAttribute = new Vector3(initialAttribute.x, initialAttribute.y, initialAttribute.z + value);
                break;
            default:
                break;
        }
    }

    private void Update()
    {
        if (IsRunning())
        {
            if (timer <= totalTime)
            {
                switch (axis)
                {
                    case 0:
                        forma.transform.eulerAngles = new Vector3(Mathf.Lerp(initialAttribute.x, endAttribute.x, ac.Evaluate(timer / totalTime)), endAttribute.y, endAttribute.z);
                        break;
                    case 1:
                        forma.transform.eulerAngles = new Vector3(endAttribute.x, Mathf.Lerp(initialAttribute.y, endAttribute.y, ac.Evaluate(timer / totalTime)), endAttribute.z);
                        break;
                    case 2:
                        forma.transform.eulerAngles = new Vector3(endAttribute.x, endAttribute.y, Mathf.Lerp(initialAttribute.z, endAttribute.z, ac.Evaluate(timer / totalTime)));
                        break;
                    default:
                        break;
                }
                timer += Time.deltaTime;
            }
            else
            {
                SetRunning(false);
                timer = 0.0f;
                forma.GetComponent<Forma>().RemoveTransform();
                Destroy(gameObject);
            }
        }
    }

    public override void Execute(GameObject _forma)
    {
        forma = _forma;
        SetRunning(true);
    }
}
