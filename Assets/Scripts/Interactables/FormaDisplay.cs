using System;
using UnityEngine;
using UnityEngine.UI;

public class FormaDisplay : MonoBehaviour
{

    public Text partName;
    public Text severity;
    public Text initialPos;
    public Text endPos;
    public Animator anim;
    public Vector3 offset;
    public int minDistance = 2;
    public Vector3 initScale;

    private void Start()
    {
        initScale = transform.localScale;
    }

    private void Update()
    {
        if ((transform.parent.position - GameManager.Get().player.transform.position).magnitude > minDistance)
        {
            transform.localScale = initScale;
        }
        else
        {
            transform.localScale = initScale * 2;
        }
        transform.LookAt(2 * transform.position - GameManager.Get().player.transform.position);
        //Vector3 pos = Vector3
    }

    public void SetInformation(GameObject forma)
    {        
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
        endPos.text = "X:" + f.GetEndPosition().x + " Y:" + f.GetEndPosition().y + " Z:" + f.GetEndPosition().z;
    }

    public void EndDisplay()
    {        
        anim.SetBool("Appear", false);        
    }

    public void StartDisplay()
    {
        anim.SetBool("Appear", true);        
    }
}
