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
    Vector3 lookPos;
    CapsuleCollider playerCollider;

    void Start()
    {
        playerCollider = gameObject.GetComponent<CapsuleCollider>();
    }

    bool IsGrounded()
    {
        Vector3 dwn = transform.TransformDirection(Vector3.down);

        return (Physics.Raycast(transform.position, dwn, 1));
    }



    void Update()
    {
        Turning();

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

  

        void Turning()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100))
            {
                lookPos = hit.point;
            }

            Vector3 lookDir = lookPos - transform.position;
            lookDir.y = 0;

            transform.LookAt(transform.position + lookDir, Vector3.up);
        }

    }
}
