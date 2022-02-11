using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    public float moveIng;

    public Rigidbody rb;

    public Transform groundPoint;
    public LayerMask groundLayer;
    public bool isGrounded;

    bool facingRight;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        moveIng = Input.GetAxisRaw("Horizontal");

        Vector3 moveEr = new Vector3(moveIng * speed, rb.velocity.y);

        Vector3 Flipping = transform.localScale;

        if(moveIng > 0 && !facingRight)
        {
            Flip();
        }
        if (moveIng < 0 && facingRight)
        {
            Flip();
        }

        rb.velocity = moveEr;

        RaycastHit hit;
        if(Physics.Raycast( groundPoint.position, Vector3.down ,out hit, .3f ,groundLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            rb.velocity += new Vector3(0f, jumpForce, 0f);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundPoint.position, .3f);
    }

    void Flip()
    {
        //Flipping Player
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
