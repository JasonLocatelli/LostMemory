using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    // Vitesse de déplacement
    public float walkSpeed;
    public float runSpeed;

    // Inputs
    public string inputFront;
    public string inputBack;
    public string inputLeft;
    public string inputRight;

    public Vector3 jumpSpeed;
    CapsuleCollider playerCollider;
    
    void Start()
    {
        playerCollider = gameObject.GetComponent<CapsuleCollider>();
    }

    bool IsGrounded()
    {
        return Physics.CheckCapsule(playerCollider.bounds.center, new Vector3(playerCollider.bounds.center.x, playerCollider.bounds.min.y - 0.1f, playerCollider.bounds.center.z), 0.5f);
    }

    void Update()
    {
        // Avancer
        if (Input.GetKey(inputFront) && !Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0, 0, runSpeed * Time.deltaTime);
        }
        if (Input.GetKey(inputFront) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0, 0, walkSpeed * Time.deltaTime);
        }

        // Reculer
        if (Input.GetKey(inputBack) && !Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0, 0, -runSpeed * Time.deltaTime);
        }
        // Sprint
        if (Input.GetKey(inputBack) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0, 0, -walkSpeed * Time.deltaTime);
        }

        // Gauche
        if (Input.GetKey(inputLeft) && !Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(-runSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(inputLeft) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(-walkSpeed * Time.deltaTime, 0, 0);
        }

        // Droite
        if (Input.GetKey(inputRight) && !Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(runSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(inputRight) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(walkSpeed * Time.deltaTime, 0, 0);
        }

        // Sauter
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            // Préparation du saut
            Vector3 v = gameObject.GetComponent<Rigidbody>().velocity;
            v.y = jumpSpeed.y;

            gameObject.GetComponent<Rigidbody>().velocity = jumpSpeed;
        }

    }
}
