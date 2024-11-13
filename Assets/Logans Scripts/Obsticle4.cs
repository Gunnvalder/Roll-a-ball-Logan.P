using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obsticle4 : MonoBehaviour
{

    public float speed = 1;
    Vector3 pointA;
    Vector3 pointB;

    // Start is called before the first frame update
    void Start()
    {
        pointA = transform.position = new Vector3(-18, 0, 62);
        pointB = transform.position = new Vector3(17, 0, 62);
    }

    // Update is called once per frame
    void Update()
    {
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(pointA, pointB, time);
    }
}