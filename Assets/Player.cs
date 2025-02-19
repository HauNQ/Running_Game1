using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public bool runBegun;

    public Rigidbody2D rb;

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

        checkInput();
    }

    private void checkInput()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Type A Key");
            runBegun = true;
        }

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("I am jumping " + jumpForce);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
}
