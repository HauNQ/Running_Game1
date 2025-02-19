using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Move Infor")]
    [SerializeField]private float moveSpeed;
    [SerializeField] private float jumpForce;
    private bool runBegun;

    private Rigidbody2D rb;
    private Animator anim;

    [Header("Collission Infor")]
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    private bool isGrounded;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Starting.....");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (runBegun)
        {
            Debug.Log("Running.....");
            rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
        }

        CheckCollission();
        checkInput();
    }

    private void CheckCollission()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundMask);
    }

    private void checkInput()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Type A Key");
            runBegun = true;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Debug.Log("I am jumping " + jumpForce);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y-groundCheckDistance));
    }
}
