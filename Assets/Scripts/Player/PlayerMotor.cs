using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    // Vitesse de déplacement
    public float walkSpeed;
    public float speed;

    // Vitesse du saut
    public float jumpForce = 150f;

    bool sprint;

    Vector3 movement;
    Vector3 lookPos;

    Rigidbody playerRigidbody;
    CapsuleCollider playerCollider;


    PlayerStats playerStats;
    void Start()
    {
        playerStats = gameObject.GetComponent<PlayerStats>();
        playerCollider = gameObject.GetComponent<CapsuleCollider>();
        playerRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        

    }

    private void FixedUpdate()
    {
        // Mouvement 
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Move(h, v);
        Turning();

 
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void Turning()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            lookPos = hit.point;
        }

        Vector3 lookDir = lookPos - transform.position;
        lookDir.y = 0;

        transform.LookAt(transform.position + lookDir, Vector3.up);
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);

        movement = movement.normalized * speed * Time.deltaTime;

        playerRigidbody.MovePosition(transform.position + movement);
    }
    
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, playerCollider.bounds.extents.y + 0.1f);
    }
    

}
