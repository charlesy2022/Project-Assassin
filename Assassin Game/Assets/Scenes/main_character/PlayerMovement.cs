using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    private void Start()
    {
        bool North = false;
        bool East = false;
        bool South = false;
        bool West = false;
        bool isAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Movement Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //ternary operator to check if diagonal movement is present
        int isDiagonal = x * y != 0 ? 0 : 1;

        //Character positioning
        transform.position += new Vector3(x, y, 0) * isDiagonal * Time.deltaTime * moveSpeed;

        //Character direction conditions
        if (movement.y > 0)
        {
            setDirection("North");
        }

        else if (movement.y < 0)
        {
            setDirection("South");
        }

        if (movement.x > 0)
        {
            setDirection("East");
        }

        else if (movement.x < 0)
        {
            setDirection("West");
        }

        //Attack Input
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isAttack", true);
        }

    }

    //Sets the direction character is facing based on conditions
    void setDirection(string direction)
    {
        animator.SetBool("North", false);
        animator.SetBool("South", false);
        animator.SetBool("East", false);
        animator.SetBool("West", false);

        animator.SetBool(direction, true);
    }

    void StopAttack()
    {
        if (animator.GetBool("isAttack"))
            animator.SetBool("isAttack", false);
    }

    void FixedUpdate()
    {
        //Movement
        if (animator.GetBool("isAttack") == true)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
