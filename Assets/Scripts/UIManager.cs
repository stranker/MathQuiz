using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager instance;
    public Text weaponName;
    public Text eje;
    public Text valor;
    public Text posicion;
    public Text rotacion;
    #region Singleton
    private void Awake()
    {

        instance = this;
    }
    public static UIManager Get()
    {
        return instance;
    }
    #endregion
    void Update () {
        weaponName.text = GameManager.Get().player.GetComponent<Player>().GetWeaponName();
        switch (GameManager.Get().player.GetComponent<Player>().GetWeapon().GetComponent<Transformators>().GetEje())
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
        valor.text = "VALOR " + GameManager.Get().player.GetComponent<Player>().GetWeapon().GetComponent<Transformators>().GetValor().ToString();
    }
    public void DrawText(GameObject forma)
    {
        
        posicion.text = forma.transform.position.x.ToString(".0") + "," + forma.transform.position.y.ToString(".0") + "," + forma.transform.position.z.ToString(".0");
        rotacion.text = (forma.transform.rotation.x*360).ToString("0") + "°," + (forma.transform.rotation.y*360).ToString("0") + "°," + (forma.transform.rotation.z * 360).ToString("0") + "°";
    }
}
