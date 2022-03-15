using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;
    private float movementSpeed = 5f;
    private Vector2 movement;
    private RaycastHit2D hit;
    private float rayDistance = 5f;
    public Transform objectRay;

    Vector2 lookDirection = new Vector2(1, 0);

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        if (!Mathf.Approximately(movement.x, 0.0f))
        {
            lookDirection.Set(movement.x, movement.y);
            lookDirection.Normalize();
        }

        Debug.DrawRay(transform.position, lookDirection * rayDistance, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, lookDirection, rayDistance);
        if (Input.GetKey(KeyCode.X))
        {
            if (hit.collider != null && hit.collider.tag == "Movable")
            {
                Debug.Log("Object: " + hit.collider.gameObject);
                hit.collider.transform.position = new Vector2(transform.position.x + 5f, transform.position.y);
            }
        }
    }
}