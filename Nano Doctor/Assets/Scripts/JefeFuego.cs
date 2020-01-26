using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JefeFuego : MonoBehaviour
{

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject proyectil;
    public Animator blackScreen;
    public Animator animator;

    public int health;


    // Start is called before the first frame update
    void Start()
    {
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBtwShots <= 0)
        {
            Instantiate(proyectil, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    public void bossTakeDamage(int damage)
    {
        health -= damage;

        if(health <= 15)
            startTimeBtwShots = 0.7f;

        if (health <= 0)
        {
            timeBtwShots = 9f;
            startTimeBtwShots = 9f;
            StartCoroutine(bossDie());
        }
    }

    public IEnumerator bossDie()
    {
        Debug.Log("Has ganado!");
        animator.SetBool("bossDead", true); //La idle será su animación de muerte ya que aquí no tiene ojo
        yield return new WaitForSeconds(1.5f);
        blackScreen.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Ending");
    }
}
