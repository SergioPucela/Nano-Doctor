using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanqueNano : MonoBehaviour
{
    public ArmaLaser player;
    public int carga;

    // Start is called before the first frame update
    void Start()
    {
        carga = Random.Range(0, 7);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Jugador")
        {
            player.cargador += carga;
            Destroy(gameObject);
        }
    }
}
