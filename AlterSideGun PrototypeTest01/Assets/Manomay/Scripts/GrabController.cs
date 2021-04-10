using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    public static bool isgrabbed;
    // Start is called before the first frame update
    public Transform grabDetect;
    public Transform ObjectHolder;
    public float rayDist;
    
   
    public LayerMask layer;
    GameObject obj=null;
    RaycastHit2D hit;
    Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    { if (obj == null)
        {
           hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), rayDist, layer);
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {   
            

            if (hit.collider != null && obj==null )
            {
                Debug.Log("Hit");
                
                obj = hit.collider.gameObject;
                obj.transform.SetParent(ObjectHolder);
                obj.GetComponent<Rigidbody2D>().simulated = false;
                isgrabbed = true;
                rb = obj.GetComponent<Rigidbody2D>();
            } 
        }

        else 
        {  if (obj != null)
            {
                obj.transform.SetParent(null);
               rb.simulated = true;
                obj = null;
                isgrabbed = false;
                rb.velocity = new Vector2(0f, 0f);
                
            }

        }

    }
}
