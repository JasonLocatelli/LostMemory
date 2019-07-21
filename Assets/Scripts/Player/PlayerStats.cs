using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float charisme;

    public float vie;
    public float vieMAX;

    public float energie;
    public float energieMAX;

    public float soif;
    public float soifMAX;

    // private float faimtime = 1;
    public float faim;
    public float faimMAX;

    public int attaque;
    public int force;
    public int armure;

    // Controle de la soif
    IEnumerator timeSoif()
    {
        while (soif > 0)
        {
            yield return new WaitForSeconds(60);
            soif -= 1f;
            Debug.Log("Votre soif baisse");
            if (soif <= 0f)
            {
                StartCoroutine(timeSoif());
            }
        }
    }

    IEnumerator timeSoifZero()
    {
        while (soif == 0f)
        {
            yield return new WaitForSeconds(30);
            vie -= 1f;
            Debug.Log("Votre Vie baisse");
            if (soif <= 0f)
            {
                StartCoroutine(timeSoifZero());
            }
        }
    }

    // Controle de la faim
    IEnumerator timeFaim()
    {
        while (faim > 0)
        {
            yield return new WaitForSeconds(120);
            faim -= 1f;
            Debug.Log("Votre Faim baisse");
            if (faim <= 0f)
            {
                StartCoroutine(timeFaim());
            }
        }
    }

    IEnumerator timeFaimZero()
    {
        while (faim == 0f)
        {
            yield return new WaitForSeconds(60);
            vie -= 1f;
            Debug.Log("Votre Vie baisse");
            if (faim <= 0f)
            {
                StartCoroutine(timeFaimZero());
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        vieMAX = vie;
        soifMAX = soif;
        energieMAX = energie;
        faimMAX = faim;
        // Lancement des timers de faim et de soif
        /*
        StartCoroutine(timeSoif());
        StartCoroutine(timeFaim());
        */
    }

    // Update is called once per frame
    void Update()
    {

        // Delimitation des caractéristiques du joueur

        // Delimitation de l'energie
        if (energie < 0)
        {
            energie = 0;
        }

        if (energie > energieMAX)
        {
            energie = energieMAX;
        }

        /*
        if (energie < energieMAX)
        {
            energie += 0.20f * Time.deltaTime;
        }
        */

        // Delimitation de la soif
        if (soif < 0)
        {
            soif = 0;
        }

        if (soif > soifMAX)
        {
            soif = soifMAX;
        }

        // Delimitation de la faim
        if (faim < 0)
        {
            faim = 0;
        }

        if (faim > faimMAX)
        {
            faim = faimMAX;
        }

        // Delimitation de la vie
        if (vie < 0)
        {
            vie = 0;
        }


        if (vie > vieMAX)
        {
            vie = vieMAX;
        }

        // Mort du joueur 
        if (vie <= 0)
        {
            Debug.Log("Mort");
            Destroy(gameObject);
        }
    }
}
