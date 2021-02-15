using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float jumpSpeed = 1f;
    float moveX = 0f;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            float jumpY = Input.GetAxis("Jump") * jumpSpeed * Time.deltaTime;
            float forceX = moveX * moveSpeed * Time.deltaTime;
            Vector2 force = new Vector2(forceX, jumpY);
            rb.AddForce(force);
        }
        else
        {
            moveX = Input.GetAxis("Horizontal1");
            float jumpY = Input.GetAxis("Jump1") * jumpSpeed * Time.deltaTime;
            float forceX = moveX * moveSpeed * Time.deltaTime;
            Vector2 force = new Vector2(forceX, jumpY);
            rb.AddForce(force);
        }
    }
}
