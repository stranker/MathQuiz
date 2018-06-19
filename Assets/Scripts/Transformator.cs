using UnityEngine;

public class Transformator : MonoBehaviour
{
    enum EJE
    {
        X,
        Y,
        Z,
        LAST
    }
    public int eje;
    public int valor;

    public void NextEje()
    {
        eje++;
        eje = eje % (int)EJE.LAST;
    }

    public virtual void Transformate(GameObject forma)
    {

    }

    public int GetEje()
    {
        return eje;
    }

    public float GetValor()
    {
        return valor;
    }
}
