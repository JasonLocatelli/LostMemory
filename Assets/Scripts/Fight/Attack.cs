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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            
        }

        if (other.tag == "Player")
        {

        }
    }
}
