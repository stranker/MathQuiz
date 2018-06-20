﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {

    public List<GameObject> transformadores;
    private GameObject currWeapon;
    public LayerMask layerForma;
    public GameObject currForma;
    
    // Use this for initialization
    void Start () {
        ActivarArma(0);
	}
	
	// Update is called once per frame
	void Update () {
        ChangeWeapon();
        ChangeAxis();
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 10, layerForma))
        {
            if (hit.transform.tag == "Forma")
            {
                currForma = hit.collider.gameObject;
                currForma.GetComponent<Forma>().DisplayInfo();
            }
        }
        else
        {
            if (currForma)
            {
                currForma.GetComponent<Forma>().EndDisplay();
                currForma = null;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 10, layerForma))
            {
                Debug.Log("HIT");
                if (hit.transform.tag == "Forma")
                {
                    currWeapon.GetComponent<Transformator>().Transformate(hit.transform.gameObject);
                    UIManager.Get().DrawText(hit.transform.gameObject);
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
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            ActivarArma(3);
    }

    private void ChangeAxis()
    {
        if (Input.GetMouseButtonDown(1))
            currWeapon.GetComponent<Transformator>().NextEje();
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
