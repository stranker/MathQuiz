using UnityEngine;

public class Rotation : Transformacion
{
    public GameObject forma;
    public Vector3 initialRotation;
    public Vector3 endRotation;
    public AnimationCurve ac;
    public float totalTime;
    public float timer;

    private void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        if (IsRunning())
        {
            if (timer <= totalTime)
            {
                switch ()
                {
                    case 0:
                        forma.transform.eulerAngles = new Vector3(Mathf.Lerp(initialRotation.x, endRotation.x, ac.Evaluate(timer / totalTime)), endRotation.y, endRotation.z);
                        break;
                    case 1:
                        forma.transform.eulerAngles = new Vector3(endRotation.x, Mathf.Lerp(initialRotation.y, endRotation.y, ac.Evaluate(timer / totalTime)), endRotation.z);
                        break;
                    case 2:
                        forma.transform.eulerAngles = new Vector3(endRotation.x, endRotation.y, Mathf.Lerp(initialRotation.z, endRotation.z, ac.Evaluate(timer / totalTime)));
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
                forma.GetComponent<Forma>().RemoveTransform(this);
                Destroy(gameObject);
            }
        }
    }

    public override void Execute(GameObject _forma)
    {
        forma = _forma;
        initialRotation = forma.transform.eulerAngles;
        switch (axis)
        {
            case 0:
                endRotation = new Vector3(initialRotation.x + valor, initialRotation.y, initialRotation.z);
                break;
            case 1:
                endRotation = new Vector3(initialRotation.x, initialRotation.y + valor, initialRotation.z);
                break;
            case 2:
                endRotation = new Vector3(initialRotation.x, initialRotation.y, initialRotation.z + valor);
                break;
            default:
                break;
        }
        SetRunning(true);
    }
}
