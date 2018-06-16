using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeManager : MonoBehaviour
{
    #region singleton   
    private static ShapeManager instance;
    public static ShapeManager Get()
    {
        return instance;
    }
    private void Awake()
    {
        if (!instance)
            instance = this;
        else
            Destroy(this.gameObject);
    }
    #endregion

    public float totalTime = 3;
    private List<IEnumerator> commandList;
    private bool running;
    private Vector3 endPos;
    private Vector3 endRot;

    private void Start()
    {
        transform.position = GameManager.Get().GetStartPos();
        running = false;
        commandList = new List<IEnumerator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !running)
        {
            ExecuteCommand();
        }
    }
    private void ExecuteCommand()
    {
            Debug.Log("EXECUTE");
            StartCoroutine(CicleList());        
    }

    private IEnumerator CicleList()
    {
        running = true;
        for (int i = 0; i < commandList.Count; i++)
        {
            StartCoroutine(commandList[i]);
            yield return new WaitForSeconds(totalTime+1);
        }
        RoundToInt();
        if (transform.position == endPos && transform.eulerAngles == endRot)
        {
            GameManager.Get().Win();
        }
        else
        {
            GameManager.Get().Restart();
        }
        commandList.Clear();
        running = false;
    }
    public void AddCommand(IEnumerator command)
    {
        Debug.Log("COMMAND");
        if(!running)
        commandList.Add(command);
    }
    public float GetTime()
    {
        return totalTime;
    }
    private void RoundToInt()
    {
        endPos = GameManager.Get().GetEndPos();
        endPos = new Vector3(Mathf.RoundToInt(endPos.x), Mathf.RoundToInt(endPos.y), Mathf.RoundToInt(endPos.z));
        endRot = GameManager.Get().GetEndRot();
        endRot = new Vector3(Mathf.RoundToInt(endRot.x), Mathf.RoundToInt(endRot.y), Mathf.RoundToInt(endRot.z));
    }
    public void StopExecute()
    {
        StopAllCoroutines();
    }
    public void ResetPos()
    {
        transform.position = GameManager.Get().GetStartPos();
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            StopExecute();
            ResetPos();
        }
    }
}

