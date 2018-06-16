using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager instance;
    public static GameManager Get()
    {
        return instance;
    }
    public Vector3 endPos;
    public Vector3 endRot;
    public Vector3 startPos;
    public GameObject player;

    void Awake()
    {
        if (!instance)
            instance = this;
        else
            Destroy(gameObject);
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
    public void Win()
    {
        Debug.Log("WIN");
    }
    public void Restart()
    {
        Debug.Log("LOSE");
    }
}
