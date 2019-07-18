using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    
    public float charisme = 10f;

    public float vie = 5f;
    public float MAXvie = 5f;
    public float MINvie = 0;

    public float energie = 7f;
    public float MAXenergie = 7f;
    public float MINenergie = 0f;

    public float soif = 10f;
    public float MAXsoif = 10f;
    public float MINsoif = 0f;

    private float faimtime = 1;
    public float faim = 10f;
    public float MAXfaim = 10f;
    public float MINfaim = 0f;

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
        if (energie < MINenergie)
        {
            energie = MINenergie;
        }

        if (energie > MAXenergie)
        {
            energie = MAXenergie;
        }

        if (energie < MAXenergie)
        {
            energie += 0.20f * Time.deltaTime;
        }

        // Delimitation de la soif
        if (soif < MINsoif)
        {
            soif = MINsoif;
        }

        if (soif > MAXsoif)
        {
            soif = MAXsoif;
        }

        // Delimitation de la faim
        if (faim < MINfaim)
        {
            faim = MINfaim;
        }

        if (faim > MAXfaim)
        {
            faim = MAXfaim;
        }

        // Delimitation de la vie
        if (vie < MINvie)
        {
            vie = MINvie;
        }


        if (vie > MAXvie)
        {
            vie = MAXvie;
        }

        // Mort du joueur 
        if (vie <= 0)
        {
            Debug.Log("Mort");
            Destroy(gameObject);
        }
    }
}
