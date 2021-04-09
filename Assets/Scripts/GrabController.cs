using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform grabDetect;
    public Transform ObjectHolder;
    public float rayDist;

   
    // Update is called once per frame
    void Update()
    {
        RaycastHit2D grabcheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist);
        if (grabcheck.collider != null && grabcheck.collider.tag == "RayObject")
        {
            if(Input.GetButton("Fire1"))
            {
                grabcheck.collider.gameObject.transform.parent = ObjectHolder;
                grabcheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            }
            else
            {
                grabcheck.collider.gameObject.transform.parent = null;
                grabcheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }
        
    }
}
