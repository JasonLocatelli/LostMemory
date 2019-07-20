using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform owner;

    // Start is called before the first frame update
    void Start()
    {
        owner = gameObject.transform.root;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
 
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("Attaque");
            if (collider.gameObject.tag == "Enemy")
            {
                Debug.Log(collider.GetComponent<EnemyStats>().vie -= owner.GetComponent<PlayerStats>().force);
            }

            if (collider.gameObject.tag == "Player")
            {
            Debug.Log(collider.GetComponent<PlayerStats>().vie -= owner.GetComponent<EnemyStats>().force);
            }
        }
    }
}
