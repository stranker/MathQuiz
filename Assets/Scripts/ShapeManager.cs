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
    private List<GameObject> commandList;
    private bool running;
    public Vector3 endPos;
    public Vector3 endRot;
    public Vector3 startPos;

    private void Start()
    {
        transform.position = GetStartPos();
        running = false;
        commandList = new List<GameObject>();
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
            commandList[i].GetComponent<Transformations>().Play();
            yield return new WaitForSeconds(totalTime + 1);
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
    public void AddCommand(GameObject command)
    {        
        if (!running)
        {
            commandList.Add(command);
            Debug.Log(commandList.Count);
        }
    }
    public void StopExecute()
    {        
        StopAllCoroutines();
        commandList.Clear();
        running = false;
    }
    public void ResetPos()
    {
        transform.position = GetStartPos();
        transform.rotation = Quaternion.Euler(Vector3.zero);
        running = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            StopExecute();
            ResetPos();
        }
    }

    private void RoundToInt()
    {
        endPos = GetEndPos();
        endPos = new Vector3(Mathf.RoundToInt(endPos.x), Mathf.RoundToInt(endPos.y), Mathf.RoundToInt(endPos.z));
        endRot = GetEndRot();
        endRot = new Vector3(Mathf.RoundToInt(endRot.x), Mathf.RoundToInt(endRot.y), Mathf.RoundToInt(endRot.z));
    }
    public float GetTime()
    {
        return totalTime;
    }
    public Vector3 GetStartPos()
    {
        return startPos;
    }
    public Vector3 GetEndPos()
    {
        return endPos;
    }
    public Vector3 GetEndRot()
    {
        return endRot;
    }
}

