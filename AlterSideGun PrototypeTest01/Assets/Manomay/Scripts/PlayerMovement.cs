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

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

  

     

    private void Start()
    {
     
        rb = GetComponent<Rigidbody2D>(); 
     
        
    }

    private void FixedUpdate()
    { 
          isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround); //check ground for jump
           
                
                //KeyBoard Movement

            moveInput = Input.GetAxis("Horizontal");

           

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
       
      
       
        if ((Input.GetKeyDown(KeyCode.UpArrow) ) && isGrounded == true)
            {
                rb.velocity = Vector2.up * jumpforce;
               
            }
        
         
            
    }

    //Flip character FUNCTION
    void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
   
  
}
