using System;
using UnityEngine;
using UnityEngine.UI;

public class FormaDisplay : MonoBehaviour
{

    public Text partName;
    public Text severity;
    public Text initialPos;
    public Text endPos;

    private void Start()
    {
    }

    public void SetInformation(GameObject forma)
    {
        SetActiveLabels(true);
        Forma f = forma.GetComponent<Forma>();
        partName.text = f.name;
        switch (f.severity)
        {
            case 0:
                severity.text = "Facil";
                severity.color = Color.green;
                break;
            case 1:
                severity.text = "Medio";
                severity.color = Color.yellow;
                break;
            case 2:
                severity.text = "Alto";
                severity.color = Color.red;
                break;
            default:
                break;
        }
        initialPos.text = "X:" + f.initialPosition.x + " Y:" + f.initialPosition.y + " Z:" + f.initialPosition.z;

    }

    public void EndDisplay()
    {
        SetActiveLabels(false);
    }

    private void SetActiveLabels(bool val)
    {
        partName.gameObject.SetActive(val);
        severity.gameObject.SetActive(val);
        initialPos.gameObject.SetActive(val);
        endPos.gameObject.SetActive(val);
    }

}
