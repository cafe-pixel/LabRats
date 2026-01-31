using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    //inputs
    private float x;

    private float y;

    private float z;
    
    
    
    //input-keys
    [SerializeField] private KeyCode jump = KeyCode.Space;
    
    //forces
    [SerializeField] private float movementForce; //10
    [SerializeField] private float gravity;
    [SerializeField] private float jumpForce;
    
    //references
    private Rigidbody rb;
    
    //states
    private string state = "movement";
    
    //can
    private bool canJump = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Movement();

        if (Input.GetKeyDown(jump)&&canJump)
        {
            Jump();
        }

        
        
    }

    private void FixedUpdate()
    {
        if (!canJump)
        {
            rb.AddForce(Vector3.down * gravity, ForceMode.Force);
        }
    }

    private void Movement()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");


        Vector3 moveDir = transform.right * x + transform.forward * z; //transform hace q mires en cuestion al jugador
        rb.linearVelocity = moveDir * movementForce;


    }

    private void Jump()
    {
        rb.AddForce(Vector3.up.normalized*jumpForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Path"))
        {
            canJump = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Path"))
        {
            canJump = false;
        }
    }

    public void Knockback(Vector3 knockDirection, float damage)
    {
        rb.isKinematic = false;
        rb.AddForce(knockDirection * damage, ForceMode.Impulse);
    }
}
