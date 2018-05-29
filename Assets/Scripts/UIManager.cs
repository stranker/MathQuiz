using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text weaponName;
    public Text eje;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        weaponName.text = GameManager.Get().player.GetComponent<Player>().GetWeaponName();
	}
}
