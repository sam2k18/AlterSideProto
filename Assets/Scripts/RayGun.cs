using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RayGun : MonoBehaviour
{
    public Transform FirePoint;
    //public Sprite Square;
    //ublic Vector2 scalechange = new Vector2(10f, 10f);
    public float a = 2.0f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(FirePoint.position, FirePoint.right);
        if(hitInfo && Input.GetKey(KeyCode.LeftShift))
        {
            hitInfo.transform.localScale = new Vector2(hitInfo.transform.localScale.x + a * Time.deltaTime, hitInfo.transform.localScale.y + a * Time.deltaTime);
        }
        if(hitInfo && Input.GetKey(KeyCode.LeftControl))
        {
            hitInfo.transform.localScale = new Vector2(hitInfo.transform.localScale.x - a * Time.deltaTime, hitInfo.transform.localScale.y - a * Time.deltaTime);
        }
    }
}
