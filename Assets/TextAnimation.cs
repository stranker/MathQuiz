using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextAnimation : MonoBehaviour
{    
    public float letterPaused = 0.01f;    
    public string message;    
    public Text textComp;

    // Use this for initialization
    void Start()
    {        
        message = textComp.text;        
        textComp.text = "";        
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {        
        foreach (char letter in message.ToCharArray())
        {            
            textComp.text += letter;
            yield return 0;
            yield return new WaitForSeconds(letterPaused);
        }
    }
}
