using UnityEngine;

public class Scale : Transformacion {

    // Use this for initialization
    void Start () {
        timer = 0;
    }

    public override void Create(GameObject _forma, int value, int eje)
    {
        base.Create(_forma, value, eje);
        initialAttribute = forma.transform.localScale;
        switch (axis)
        {
            case 0:
                endAttribute = initialAttribute + Vector3.right * value;
                break;
            case 1:
                endAttribute = initialAttribute + Vector3.up * value;
                break;
            case 2:
                endAttribute = initialAttribute + Vector3.forward * value;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update () {

        if (IsRunning())
        {
            if (timer <= totalTime)
            {
                Vector3 scale = Vector3.Lerp(initialAttribute, endAttribute, ac.Evaluate(timer / totalTime));
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
        SetRunning(true);
    }

}
