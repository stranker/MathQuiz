using UnityEngine;

public class Scale : Transformacion {

    public GameObject forma;
    public Vector3 initialScale;
    public Vector3 endScale;
    public AnimationCurve ac;
    public float totalTime;
    public float timer;

    // Use this for initialization
    void Start () {
        timer = 0;
    }
	
	// Update is called once per frame
	void Update () {

        if (IsRunning())
        {
            if (timer <= totalTime)
            {
                Vector3 scale = Vector3.Lerp(initialScale, endScale, ac.Evaluate(timer / totalTime));
                forma.transform.localScale = scale;
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
        initialScale = forma.transform.localScale;
        switch (axis)
        {
            case 0:
                endScale = initialScale + Vector3.right * valor;
                break;
            case 1:
                endScale = initialScale + Vector3.up * valor;
                break;
            case 2:
                endScale = initialScale + Vector3.forward * valor;
                break;
            default:
                break;
        }
        SetRunning(true);
    }

}
