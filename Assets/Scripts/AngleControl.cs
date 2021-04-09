using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleControl : MonoBehaviour
{
    public Vector2 currentAngles;
    // Start is called before the first frame update
    void Start()
    {
        currentAngles = new Vector2(transform.rotation.x, transform.rotation.y);
    }
   // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = currentAngles;
    }
}
