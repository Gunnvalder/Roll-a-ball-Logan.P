using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obsticle2 : MonoBehaviour
{

    public float speed = 1;
    Vector3 pointD;
    Vector3 pointE;

    // Start is called before the first frame update
    void Start()
    {
        pointD = transform.position = new Vector3(-7, 1, 12);
        pointE = transform.position = new Vector3(-7, 1, -12);
    }

    // Update is called once per frame
    void Update()
    {
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(pointD, pointE, time);
    }
}
