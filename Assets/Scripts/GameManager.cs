using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager instance;
    public static GameManager Get()
    {
        return instance;
    }

    public GameObject player;

    void Awake()
    {
        if (!instance)
            instance = this;
        else
            Destroy(gameObject);
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
