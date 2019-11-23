using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanqueNano : MonoBehaviour
{
    public ArmaLaser player;
    public int carga;

    // Start is called before the first frame update
    /*void Start()
    {
        carga = Random.Range(1, 5);
    }*/

    public void Cargar()
    {
        if(player.cargador < 4)
        {
            player.cargador += carga;
            Destroy(gameObject);
        }
    }
}
