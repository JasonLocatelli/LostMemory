using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float charisme;

    public float vie;
    public float vieMAX;

    public float energie;
    public float energieMAX;

    public int attaque;
    public int force;
    public int armure;

    // Start is called before the first frame update
    void Start()
    {
        vieMAX = vie;
        energieMAX = energie;
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
