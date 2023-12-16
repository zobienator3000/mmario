using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    public float horizontal;
    private bool flipRight = true;
    public Animator animator;
    public int jumpForce = 10;
    public bool onGround;
    public LayerMask Ground;
    public Transform GroundCheck;
    private float GroundCheckRadius;
    private Vector3 respawnPoint;
    public GameObject deadZone;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        GroundCheckRadius = GroundCheck.GetComponent<CircleCollider2D>().radius;
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        jump();
        CheckingGround();
        deadZone.transform.position = new Vector2(transform.position.x, deadZone.transform.position.y);
        void jump()
        {
            if (onGround && Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }

        horizontal = Input.GetAxis("Horizontal") * speed;
        rb.velocity = new Vector2(horizontal, rb.velocity.y);//(x,y)
        animator.SetFloat("moveX", Mathf.Abs(horizontal));
        if (horizontal > 0 && !flipRight)
        {
            Flip();
        }
        else if (horizontal < 0 && flipRight)
        {
            Flip();
        }
    }
    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, Ground);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DeadZone")
        {
            transform.position = respawnPoint;
        }else if(collision.tag == "checkpoint") {
            respawnPoint = transform.position;
        }
    }
    void Flip()
    {
        flipRight = !flipRight;
        Vector3 theScale = transform.localScale;
        theScale.x = theScale.x * (-1);
        transform.localScale = theScale;
    }
}