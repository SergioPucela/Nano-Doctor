using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{

    public Sprite[] imagenes;
    int imagenActual;

    float frameTime = 2.5f;
    float nextFrameTime = 1.0f;

    public Animator animator;
    public Image miImagen;

    public bool Prologo;
    public bool Ending;

    void Start()
    {
        StartCoroutine(cutscene());
    }

    IEnumerator cutscene()
    {
        for(imagenActual = 0; imagenActual < imagenes.Length; imagenActual++)
        {
            miImagen.sprite = imagenes[imagenActual];
            yield return new WaitForSeconds(frameTime);
            animator.SetTrigger("FadeOut");
            yield return new WaitForSeconds(nextFrameTime);
            if(imagenActual < imagenes.Length - 1)
                animator.SetTrigger("FadeIn");
        }

        if (Prologo)
        {
            SceneManager.LoadScene("Nivel1Tutorial");
        }
        else if (Ending)
        {
            SceneManager.LoadScene("MenuPrincipal");
        }

    }

}
