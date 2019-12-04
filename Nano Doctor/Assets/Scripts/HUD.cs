using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public PlayerMovement player;
    public ArmaLaser armaLaser;
    public PlayerInput input;

    public Image selectorDisparos;
    public Image barraVida;
    public Image barraCargas;

    public Sprite vidas2;
    public Sprite vidas1;
    public Sprite vidas0;

    public Sprite laser0;
    public Sprite laser1;
    public Sprite laser2;
    public Sprite laser3;
    public Sprite laser4;

    public Sprite selectorNormal;
    public Sprite selectorLaser;

    // Update is called once per frame
    void Update()
    {
        if (player.health == 2)
            barraVida.sprite = vidas2;
        else if (player.health == 1)
            barraVida.sprite = vidas1;
        else if (player.health == 0)
            barraVida.sprite = vidas0;

        if (armaLaser.cargador == 0)
            barraCargas.sprite = laser0;
        else if (armaLaser.cargador == 1)
            barraCargas.sprite = laser1;
        else if (armaLaser.cargador == 2)
            barraCargas.sprite = laser2;
        else if (armaLaser.cargador == 3)
            barraCargas.sprite = laser3;
        else if (armaLaser.cargador == 4)
            barraCargas.sprite = laser4;

        if (input.armaEquipada)
            selectorDisparos.sprite = selectorNormal;
        else
            selectorDisparos.sprite = selectorLaser;
    }
}
