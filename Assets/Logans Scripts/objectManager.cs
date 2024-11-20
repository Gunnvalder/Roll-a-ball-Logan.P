using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectManager : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    public float speed = 1f;
    
   
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {      
        
        float time = Mathf.PingPong(Time.time * speed, 1f);
        transform.position = Vector3.Lerp(pointA.position, pointB.position, time);
    }
}