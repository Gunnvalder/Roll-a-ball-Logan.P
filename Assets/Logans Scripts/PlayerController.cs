using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Xml.Linq;
using UnityEngine.UI;
using JetBrains.Annotations;
using System.Runtime.CompilerServices;
using UnityEditor;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    private int count;

    private float movementX;
    private float movementY;

    public float speed = 0;

    public TextMeshProUGUI countText;
    public TextMeshProUGUI RightOpen;
    public TextMeshProUGUI LeftOpen;

    public GameObject winTextObject;
    public GameObject RestartButtonObject;

    float waitForRightDoor = 5;
    bool rightDoorActivated = false;
    float waitForLeftDoor = 5;
    bool leftDoorActivated = false;



    void Start()
    {
        rb = GetComponent<Rigidbody>();

        count = 0;

        SetCountText();

        winTextObject.SetActive(false);
        RestartButtonObject.SetActive(false);
        RightOpen.gameObject.SetActive(false);
        LeftOpen.gameObject.SetActive(false);
    }
    private void Update()
    {
        //if the door is active and the timer is still above 0
        if(waitForRightDoor > 0 && rightDoorActivated == true)
        {
            //decrement the timer (countdown)
            waitForRightDoor -= Time.deltaTime;
            //Debug.Log(waitForRightDoor);
        }
        //otherwise, if the timer is at or below 0
        else if (waitForRightDoor <= 0)
        {
            rightDoorActivated = false;
            RightOpen.gameObject.SetActive(false);
        }
        if (waitForLeftDoor > 0 && leftDoorActivated == true)
        {
            waitForLeftDoor -= Time.deltaTime;
        }
        else if (waitForLeftDoor <= 0)
        {
            leftDoorActivated = false;
            LeftOpen.gameObject.SetActive(false);
        }
        
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
            rightDoorActivated = true;
            RightOpen.gameObject.SetActive(true);
        }
        if (other.gameObject.CompareTag("DoorButton2"))
        {
            GameObject door = GameObject.FindWithTag("Door2");
            door.SetActive(false);
            leftDoorActivated = true;
            LeftOpen.gameObject.SetActive(true);
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