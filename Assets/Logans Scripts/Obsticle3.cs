using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obsticle3 : MonoBehaviour
{

    public float speed = 1;
    Vector3 pointA;
    Vector3 pointB;

    // Start is called before the first frame update
    void Start()
    {
        pointA = transform.position = new Vector3(-22, 0, 44);
        pointB = transform.position = new Vector3(-22, 0, 74);
    }

    // Update is called once per frame
    void Update()
    {
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(pointA, pointB, time);
    }
}