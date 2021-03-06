﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public List<GameObject> transformadores;
    private GameObject currWeapon;
    public LayerMask layerForma;

    // Use this for initialization
    void Start()
    {
        ActivarArma(0);
    }

    // Update is called once per frame
    void Update()
    {
        ChangeWeapon();
        ChangeAxis();



        if (Input.GetMouseButtonDown(0))
        {
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 10, Color.red, 1);
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 10, layerForma))
            {
                if (hit.transform.tag == "Forma")
                {
                    Debug.Log("Command");
                    currWeapon.GetComponent<Transformators>().Transformate();
                    //UIManager.Get().DrawText(hit.transform.gameObject);
                }
            }
        }        
    }

    private void ChangeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            ActivarArma(0);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            ActivarArma(1);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            ActivarArma(2);
    }

    private void ChangeAxis()
    {
        if (Input.GetMouseButtonDown(1))
            currWeapon.GetComponent<Transformators>().NextEje();
    }

    public void ActivarArma(int index)
    {
        for (int i = 0; i < transformadores.Count; i++)
        {
            if (i == index)
            {
                transformadores[i].gameObject.SetActive(true);
                currWeapon = transformadores[i].gameObject;
            }
            else
                transformadores[i].gameObject.SetActive(false);
        }
    }

    public GameObject GetWeapon()
    {
        return currWeapon;
    }

    public string GetWeaponName()
    {
        return currWeapon.gameObject.name;
    }
}
