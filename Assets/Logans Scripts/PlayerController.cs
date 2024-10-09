using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    private int count;

    private float movementX;
    private float movementY;

    public float speed = 0;

    public TextMeshProUGUI countText;

    public GameObject winTextObject;
    public GameObject RestartButtonObject;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        count = 0;

        SetCountText();

        winTextObject.SetActive(false);
        RestartButtonObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);

            count = count + 1;

            SetCountText();
            transform.localScale *= 1.1f;
            
        }
        if (other.gameObject.CompareTag("DoorButton"))
        {
            GameObject door = GameObject.FindWithTag("Door1");
            door.SetActive(false);
        }
        if (other.gameObject.CompareTag("DoorButton2"))
        {
            GameObject door = GameObject.FindWithTag("Door2");
            door.SetActive(false);
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 16)
        {
            winTextObject.SetActive(true);
            RestartButtonObject.SetActive(true);
        }
    }
}