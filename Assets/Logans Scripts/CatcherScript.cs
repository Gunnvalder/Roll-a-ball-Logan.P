using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatcherScript : MonoBehaviour
{

    public Rigidbody otherRb;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = new Vector3(0, 0, 0);
            otherRb.isKinematic = true;
            otherRb.isKinematic = false;
        }
        if (other.gameObject.CompareTag("ResetScaleButton"))
        {
            other.gameObject.transform.position = new Vector3(4, -11, 65);
            otherRb.isKinematic = true;
            otherRb.isKinematic = false;
        }
    }

}
