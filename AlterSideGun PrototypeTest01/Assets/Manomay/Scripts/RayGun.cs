using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RayGun : MonoBehaviour
{
    public Transform FirePoint;
    //public Sprite Square;
    //ublic Vector2 scalechange = new Vector2(10f, 10f);
    public float Speed = 2.0f;

    public float rayDist = 10f;

    public LayerMask layer;

    // Update is called once per frame
    void Update()
    {
        if (GrabController.isgrabbed == false)
        {
            Shoot();
        }
        
    }

    void Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(FirePoint.transform.position, FirePoint.transform.TransformDirection(Vector2.right), rayDist, layer);
        
        if (hitInfo && Input.GetKey(KeyCode.C)&& hitInfo.transform.localScale.x>0f && hitInfo.transform.localScale.y>0f)
        {
            hitInfo.transform.localScale = new Vector2(hitInfo.transform.localScale.x + Speed * Time.deltaTime, hitInfo.transform.localScale.y + Speed * Time.deltaTime);
        }
        if(hitInfo && Input.GetKey(KeyCode.X) && hitInfo.transform.localScale.x > 0.1f && hitInfo.transform.localScale.y > 0.1f)
        {
            Debug.Log("HitScale");
            hitInfo.transform.localScale = new Vector2(hitInfo.transform.localScale.x - Speed * Time.deltaTime, hitInfo.transform.localScale.y - Speed * Time.deltaTime);
        }
    }
}
