using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Move Infor")]
    public float moveSpeed;
    public float jumpForce;
    private bool runBegun;

    public Rigidbody2D rb;

    [Header("Collission Infor")]
    public float groundCheckDistance;
    public LayerMask groundMask;
    private bool isGrounded;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Starting.....");
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
