using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.2f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float fallThresholdY = -10f;

    public UIManager uiManager;

    private bool hasFallen = false;



    private float fallHeightThreshold = 1.5f;
    private float lastGroundedY;

    private enum GroundType { Normal, Trampoline }
    private GroundType currentGroundType = GroundType.Normal;



    private Rigidbody rb;
    private Vector2 moveInput;
    private PlayerControls controls;
    private bool isGrounded;

    private Animator animator;

    private void Awake()
    {
        controls = new PlayerControls();

        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        controls.Player.Jump.performed += ctx => Jump();
    }

    private void OnEnable() => controls.Player.Enable();
    private void OnDisable() => controls.Player.Disable();

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>(); 
    }

    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        animator.SetBool("IsGrounded", isGrounded); 

        float fallHeight = transform.position.y - lastGroundedY;
        bool isFalling = !isGrounded && rb.linearVelocity.y < -0.1f && fallHeight > fallHeightThreshold;
        animator.SetBool("IsFalling", isFalling);

        if (isGrounded)
        {
            lastGroundedY = transform.position.y;
        }

        
        Vector3 camForward = Camera.main.transform.forward;
        camForward.y = 0;
        camForward.Normalize();

        Vector3 camRight = Camera.main.transform.right;
        camRight.y = 0;
        camRight.Normalize();

        Vector3 move = camForward * moveInput.y + camRight * moveInput.x;
        move.Normalize();

        rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);

        
        if (move.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, 10f * Time.fixedDeltaTime);
        }

        
        animator.SetFloat("speed", move.magnitude);

        if (!isGrounded && rb.linearVelocity.y < -3.35f)
        {
            animator.SetBool("IsFalling", true);
        }
        else
        {
            animator.SetBool("IsFalling", false);
        }


    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetTrigger("JumpTrigger");

        }
    }


    void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.layer == LayerMask.NameToLayer("Trampoline"))
        {

            animator.SetTrigger("JumpTrigger");
        }
    }


    void OnCollisionStay(Collision collision)
    {



        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
            lastGroundedY = transform.position.y;
            currentGroundType = GroundType.Normal;
            fallHeightThreshold = 1.5f; 
        }

        else if (collision.gameObject.layer == LayerMask.NameToLayer("Trampoline"))
        {
            isGrounded = true;
            lastGroundedY = transform.position.y;
            currentGroundType = GroundType.Trampoline;
            fallHeightThreshold = 0.5f; 
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = false;
        }
    }

    void Update()
    {


        if (!hasFallen && transform.position.y < fallThresholdY)
        {
            hasFallen = true;

            if (uiManager != null)
            {
                uiManager.SetGameOver(); 
            }
        }


    }
}
