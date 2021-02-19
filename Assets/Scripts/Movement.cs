using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float jumpSpeed = 1f;
    [SerializeField] LayerMask PlatformLayerMask;
    float moveX = 0f;
    Rigidbody2D rb;
    BoxCollider2D box;
    public const string Jumpone = "Jump";
    public const string Jumptwo = "Jump1";

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb != null)
        {
            AddInput();
        }
    }

    void AddInput()
    {
        if(gameObject.tag == "Player1")
        {
            moveX = Input.GetAxis("Horizontal");
            float forceX = moveX * moveSpeed * Time.deltaTime;
            Vector2 force = new Vector2(forceX, 0f);
            rb.AddForce(force);
            if(IsGrounded() == true)
            {
                Jumping(Jumpone);
            }
        }
        else
        {
            moveX = Input.GetAxis("Horizontal1");
            float forceX = moveX * moveSpeed * Time.deltaTime;
            Vector2 force = new Vector2(forceX, 0f);
            rb.AddForce(force);
            if(IsGrounded() == true)
            {
                Jumping(Jumptwo);
            }
        }
    }

    void Jumping(string Jump)
    {
        float jumpY = Input.GetAxis(Jump) * jumpSpeed * Time.deltaTime;
        Vector2 jump = new Vector2(0, jumpY);
        rb.AddForce(jump);
    }

    private bool IsGrounded()
    {
        float extraHeight = 0.5f;
        RaycastHit2D raycastHit = Physics2D.Raycast(box.bounds.center, Vector2.down, box.bounds.extents.y + extraHeight, PlatformLayerMask);
        return raycastHit.collider != null;
    }
}
