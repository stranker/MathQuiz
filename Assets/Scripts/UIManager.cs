using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text weaponName;
    public Text eje;
    public Text valor;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        weaponName.text = GameManager.Get().player.GetComponent<Player>().GetWeaponName();
        switch (GameManager.Get().player.GetComponent<Player>().GetWeapon().GetComponent<Transformator>().GetEje())
        {
            case 0:
                eje.text = "Eje X";
                eje.color = Color.red;
                break;
            case 1:
                eje.text = "Eje Y";
                eje.color = Color.green;
                break;
            case 2:
                eje.text = "Eje Z";
                eje.color = Color.blue;
                break;
            default:
                break;
        }
        valor.text = "VALOR " + GameManager.Get().player.GetComponent<Player>().GetWeapon().GetComponent<Transformator>().GetValor().ToString();
    }
}
