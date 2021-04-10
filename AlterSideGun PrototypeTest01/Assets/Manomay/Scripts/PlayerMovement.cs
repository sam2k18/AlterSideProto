using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    
    public float speed;
    float dirx;
    public float jumpforce;
    private float moveInput;

    public Rigidbody2D rb;

   public bool facingRight = true;

    private bool isGrounded,isGroundedOnObj;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround,objects;

    public Animator animator;


     

    private void Start()
    {
     
        rb = GetComponent<Rigidbody2D>(); 
     
        
    }

    private void FixedUpdate()
    { 
          isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
          isGroundedOnObj = Physics2D.OverlapCircle(groundCheck.position, checkRadius, objects);
        //check ground for jump


        //KeyBoard Movement

        moveInput = Input.GetAxis("Horizontal");

           if(moveInput!=0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
           

            //Flip character
            if (facingRight == false && (moveInput > 0))
            {
                flip();
            }
            else if (facingRight == true && (moveInput < 0))
            {
                flip();
            }

        
        
        
    }
    private void Update()
    {
        rb.gravityScale = 1;


        if ((Input.GetKeyDown(KeyCode.W) ) && (isGrounded == true||isGroundedOnObj==true))
        {
                rb.velocity = Vector2.up * jumpforce;
            if(isGroundedOnObj)
            {
                rb.gravityScale = 0;
            }
           
               
        }
        
         
            
    }

    //Flip character FUNCTION
    void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
   
  
}
