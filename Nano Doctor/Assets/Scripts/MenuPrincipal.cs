using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{

    public Animator animator;

    IEnumerator TransitionQuit()
    {
        animator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        Debug.Log("Has salido del juego correctamente.");
        Application.Quit();
    }

    IEnumerator TransitionStart()
    {
        animator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Prologo");
    }

    public void Quit()
    {
        StartCoroutine(TransitionQuit());
    }

    public void goToLevelOne()
    {
        StartCoroutine(TransitionStart());
    }

}
