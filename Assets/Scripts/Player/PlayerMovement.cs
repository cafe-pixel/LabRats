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
    [SerializeField] private Transform cam;
    
    //states
    private string state = "movement";
    
    //can
    public bool canJump { get; set; }= false;
    private bool doubleJump;
    private bool applyGrav = false;    
    
    
    //bool
    private bool hasDoubleJumped = false;
    private bool canMakeDoubleJump = false;
    private int counterScene;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
       
        canJump = true;
        doubleJump = false;
    }

    private void Update()
    {
        Movement();

        if (Input.GetKeyDown(jump) && canJump)
        {
            Jump();
        }
        
        

    }

    private void DoubleJump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        doubleJump = false; 
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


        Vector3 moveDir = cam.transform.right * x + cam.transform.forward * z; //transform hace q mires en cuestion al jugador
        rb.linearVelocity = moveDir * movementForce;


    }

    private void Jump()
    {
        Debug.Log("Realizo un salto");
        
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        
        if (Input.GetKeyDown(jump))
        {
            Debug.Log("Quiero hacer un doble ssalto");
            DoubleJump();
        }
    }
    
    public void Knockback(Vector3 knockDirection, float damage)
    {
        rb.isKinematic = false;
        rb.AddForce(knockDirection * damage, ForceMode.Impulse);
    }

    public void CounterScene()
    {
        counterScene++;
        if (counterScene == 2) canMakeDoubleJump = true;
    }
}
