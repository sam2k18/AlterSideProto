using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeRewind : MonoBehaviour
{
    public bool isRewinding = false;

    List<PointInTime> pointsinTime;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        pointsinTime = new List<PointInTime>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            StartRewind();
        }
        if(Input.GetKeyUp(KeyCode.R))
        {
            StopRewind();
        }
    }

    private void FixedUpdate()
    {
        if(isRewinding)
        {
            Rewind();
        }
        else
        {
            Record();
        }
    }

    void Record()
    {
        if (pointsinTime.Count > Mathf.RoundToInt(7f / Time.fixedDeltaTime))
        {
            pointsinTime.RemoveAt(pointsinTime.Count - 1);
        }
            pointsinTime.Insert(0, new PointInTime(transform.position, transform.rotation));
        
    }

    void Rewind()
    { if (pointsinTime.Count > 0)
        {
            PointInTime pointInTime = pointsinTime[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            pointsinTime.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }
    }


    public void StartRewind()
    {
        isRewinding = true;
        rb.simulated = false;
    }
    public void StopRewind()
    {
        isRewinding = false;
        rb.simulated = true;
    }
}
