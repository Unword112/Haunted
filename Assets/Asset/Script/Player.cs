using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;

    public float speed;
    private float moveInput;

    private Rigidbody2D rb;
    public static SpriteRenderer rend;

    private bool facingRight = true;
    private bool live;

    private bool canhide = false;
    private bool hidding = false;

    [SerializeField]
    //private GameObject enemy;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (canhide  && Input.GetKey(KeyCode.Space))
        {
            Physics2D.IgnoreLayerCollision(6, 9, true);
            rend.sortingOrder = 0;
            hidding = true;
            Debug.Log(rend.sortingOrder);
        }
        else
        {
            Physics2D.IgnoreLayerCollision(6, 9, false);
            rend.sortingOrder = 5;
            hidding = false;
            Debug.Log(rend.sortingOrder);
        }

        if(moveInput == 0)
        {
            animator.SetBool("Walk", false);
        } else
        {
            animator.SetBool("Walk", true); 
        }
        
    }
    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal") * speed;

        if (!hidding)
            rb.velocity = new Vector2(moveInput, rb.velocity.y);
        else
            rb.velocity = Vector2.zero;


        if(facingRight == false && moveInput > 0)
        {
            Flip();
        } else if(facingRight == true && moveInput < 0){
            Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("isHide"))
        {
            canhide = true;
        }

        if (!collision.gameObject.CompareTag("Enemy"))
        {
            animator.SetBool("Die", false);
            live = true;
            Debug.Log("not Die");
        }
        else
        {
            animator.SetBool("Die", true);
            speed = 0;
            live = false;
            Debug.Log("Die");
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.CompareTag("isHide"))
        {
            canhide = false;
        }
    }

   void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
