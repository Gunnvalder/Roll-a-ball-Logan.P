using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catcher2Script : MonoBehaviour
{
    public Rigidbody otherRb;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = new Vector3(0, 0, 44);
            otherRb.isKinematic = true;
            otherRb.isKinematic = false;
        }
    }
}
