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

    private void Start()
    {
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
            yield return new WaitForSeconds(totalTime);
        }
        commandList.Clear();
        running = false;
    }
    public void AddCommand(IEnumerator command)
    {
        Debug.Log("COMMAND");
        commandList.Add(command);
    }
    public float GetTime()
    {
        return totalTime;
    }
}
