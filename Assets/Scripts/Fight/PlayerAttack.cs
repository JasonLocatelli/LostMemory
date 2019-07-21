using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform owner;

    bool attack;
    // Start is called before the first frame update
    void Start()
    {
        owner = gameObject.transform.root;
        attack = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Attaque du joueur
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Animation attaque
            attack = true;
            this.GetComponent<Collider>().isTrigger = true;
            Debug.Log("Attaque du joueur");
        }
    }

    // Collision arme sur un ennemi
    private void OnTriggerEnter(Collider collider)
    {
        if (attack == true)
        {
            if (collider.gameObject.tag == "Enemy")
            {
                collider.GetComponent<EnemyStats>().vie -= (owner.GetComponent<PlayerStats>().attaque+gameObject.GetComponent<>
            }
        }
    }
}
