using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{

    public static bool isPaused = false;

    public GameObject pauseMenuUI;
    public PlayerInput player;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Continuar();
            else
                Pausar();
        }
    }

    public void Continuar()
    {
        pauseMenuUI.SetActive(false);
        player.enabled = true;
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pausar()
    {
        pauseMenuUI.SetActive(true);
        player.enabled = false;
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void CargarMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuPrincipal");
    }
}
