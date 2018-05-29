using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Transformator : MonoBehaviour {
    enum EJE
    {
        X,
        Y,
        Z,
        LAST
    }
    public int eje;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NextEje()
    {
        eje++;
        eje = eje % (int)EJE.LAST;
    }

    abstract public void Transformate(GameObject forma);

    public int GetEje()
    {
        return eje;
    }

}
