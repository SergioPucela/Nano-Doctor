using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{

    public void Quit()
    {
        Debug.Log("Has salido del juego correctamente.");
        Application.Quit();
    }

    public void goToTestScene()
    {
        SceneManager.LoadScene("TestScene");
    }

    public void goToLevelOne()
    {
        SceneManager.LoadScene("Nivel1");
    }

}
